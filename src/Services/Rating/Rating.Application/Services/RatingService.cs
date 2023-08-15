using AutoMapper;
using Newtonsoft.Json;
using Rating.Application.IRepositories;
using Rating.Application.IServices;
using Rating.Domain.DTOs;
using Rating.Domain.Exceptions;
using System.Text;

namespace Rating.Application.Services
{
	public class RatingService : IRatingService
	{
		private readonly IRatingRepository _ratingRepository;
		private readonly IFilmRepository _filmRepository;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		private readonly IRedisService<List<Domain.Models.Rating?>> _redis;

		public RatingService(IRatingRepository ratingRepository,
			IFilmRepository filmRepository, IUserRepository userRepository,
			IMapper mapper, 
			IRedisService<List<Domain.Models.Rating?>> redis)
		{
			_ratingRepository = ratingRepository;
			_filmRepository = filmRepository;
			_userRepository = userRepository;
			_mapper = mapper;
			_redis = redis;
		}

		public async Task<Domain.Models.Rating> CreateRatingAsync(CreateRatingDTO ratingDTO)
		{
			var film = await _filmRepository.GetFilmByNameAsync(ratingDTO.FilmName)
				?? throw new NotFoundException("Not Found this filmName!");
			var user = await _userRepository.GetUserByLoginAsync(ratingDTO.UserLogin)
				?? throw new NotFoundException("Not Found this user!");

			var rating = new Domain.Models.Rating()
			{
				RatingFilm = film,
				RatingUser = user,
				FilmRating = ratingDTO.FilmRating
			};

			await _ratingRepository.CreateAsync(rating);
			await _ratingRepository.SaveAsync();

			return rating;
		}

		public async Task DeleteRating(int id)
		{
			var rating = await _ratingRepository.GetByIdAsync(id)
				?? throw new NotFoundException("Can not found this rating!");

			_ratingRepository.Delete(rating);
			await _ratingRepository.SaveAsync();
		}

		public async Task<List<RatingDTO>> GetAllRatingsAsync()
		{
			var serializedRatingList = await _redis.GetAsync();

			if(serializedRatingList == null)
			{
				var ratings = await _ratingRepository.GetAllAsync();
				var ratingDtos = _mapper.Map<List<RatingDTO>>(ratings);

				await _redis.SetAsync(ratings);

				return ratingDtos;
			}
			else
			{
				var ratings = JsonConvert.DeserializeObject<List<Domain.Models.Rating?>>(serializedRatingList);
				var ratingDtos = _mapper.Map<List<RatingDTO>>(ratings);

				return ratingDtos;
			}
		}

		public async Task<float> GetRatingByFilmNameAsync(string filmName)
		{
			int ratingSum = await _ratingRepository.GetSumRatingForFilmNameAsync(filmName);
			int count = await _ratingRepository.GetCountOfRatedUsers(filmName);

			return ratingSum / count;
		}

		public async Task UpdateRating(RatingDTO ratingDTO)
		{
			var rating = await _ratingRepository.GetByIdAsync(ratingDTO.Id)
				?? throw new NotFoundException("Can not found this rating!");

			rating = _mapper.Map<Domain.Models.Rating>(ratingDTO);

			_ratingRepository.Update(rating);
			await _ratingRepository.SaveAsync();
		}
	}
}
