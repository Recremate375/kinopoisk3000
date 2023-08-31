using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rating.Application.IRepositories;
using Rating.Application.IServices;
using Rating.Domain.DTOs;
using Rating.Domain.Exceptions;

namespace Rating.Application.Services
{
	public class RatingService : IRatingService
	{
		private readonly IRatingRepository _ratingRepository;
		private readonly IFilmRepository _filmRepository;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		private readonly IRedisService<List<Domain.Models.Rating?>> _redis;
		private readonly ILogger<RatingService> _logger;

		public RatingService(IRatingRepository ratingRepository,
			IFilmRepository filmRepository, IUserRepository userRepository,
			IMapper mapper, 
			IRedisService<List<Domain.Models.Rating?>> redis,
			ILogger<RatingService> logger)
		{
			_ratingRepository = ratingRepository;
			_filmRepository = filmRepository;
			_userRepository = userRepository;
			_mapper = mapper;
			_redis = redis;
			_logger = logger;
		}

		public async Task<Domain.Models.Rating> CreateRatingAsync(CreateRatingDTO ratingDTO)
		{
			var film = await _filmRepository.GetFilmByNameAsync(ratingDTO.FilmName);

			if (film is null)
			{
				_logger.LogError("Not Found this filmName!");

				throw new NotFoundException("Not Found this filmName!");
			}

			var user = await _userRepository.GetUserByLoginAsync(ratingDTO.UserLogin);

			if (user is null)
			{
				_logger.LogError("Not Found this user!");

				throw new NotFoundException("Not Found this user!");
			}

			var rating = new Domain.Models.Rating()
			{
				RatingFilm = film,
				RatingUser = user,
				FilmRating = ratingDTO.FilmRating
			};

			await _ratingRepository.CreateAsync(rating);
			await _ratingRepository.SaveAsync();

			_logger.LogInformation($"Rating was successfully created. Id: {rating.Id}");

			return rating;
		}

		public async Task DeleteRating(int id)
		{
			var rating = await _ratingRepository.GetByIdAsync(id);

			if (rating is null)
			{
				_logger.LogError($"Can not found this rating! Id: {id}");

				throw new NotFoundException("Can not found this rating!");
			}

			_ratingRepository.Delete(rating);
			await _ratingRepository.SaveAsync();

			_logger.LogInformation($"Rating was successfully deleted. Id: {id}");
		}

		public async Task<List<RatingDTO>> GetAllRatingsAsync()
		{
			var serializedRatingList = await _redis.GetAsync();

			if(serializedRatingList == null)
			{
				var ratings = await _ratingRepository.GetAllAsync();
				var ratingDtos = _mapper.Map<List<RatingDTO>>(ratings);

				await _redis.SetAsync(ratings);

				_logger.LogError("All ratings was successfully received and added to Redis.");

				return ratingDtos;
			}
			else
			{
				var ratings = JsonConvert.DeserializeObject<List<Domain.Models.Rating?>>(serializedRatingList);
				var ratingDtos = _mapper.Map<List<RatingDTO>>(ratings);

				_logger.LogError("All ratings was successfully received.");

				return ratingDtos;
			}
		}

		public async Task<float> GetRatingByFilmNameAsync(string filmName)
		{
			int ratingSum = await _ratingRepository.GetSumRatingForFilmNameAsync(filmName);
			int count = await _ratingRepository.GetCountOfRatedUsers(filmName);

			_logger.LogError($"Rating by filmName was successfully received.");

			return ratingSum / count;
		}

		public async Task UpdateRating(RatingDTO ratingDTO)
		{
			var rating = await _ratingRepository.GetByIdAsync(ratingDTO.Id);

			if (rating is null)
			{
				_logger.LogError("Can not found this rating!");

				throw new NotFoundException("Can not found this rating!");
			}

			rating = _mapper.Map<Domain.Models.Rating>(ratingDTO);

			_ratingRepository.Update(rating);
			await _ratingRepository.SaveAsync();

			_logger.LogInformation($"Rating was successfully updated. Id: {rating.Id}");
		}
	}
}
