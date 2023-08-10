using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
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
		private readonly IDistributedCache _cache;

		public RatingService(IRatingRepository ratingRepository,
			IFilmRepository filmRepository, IUserRepository userRepository,
			IMapper mapper, IDistributedCache cache)
		{
			_ratingRepository = ratingRepository;
			_filmRepository = filmRepository;
			_userRepository = userRepository;
			_mapper = mapper;
			_cache = cache;
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
			var cacheKey = "RatingList";
			string serializedRatingList;
			var ratings = new List<Domain.Models.Rating?>();
			var ratingDistributedList = await _cache.GetAsync(cacheKey);
			var ratingDtos = new List<RatingDTO>();

			if(ratingDistributedList != null)
			{
				serializedRatingList = Encoding.UTF8.GetString(ratingDistributedList);
				ratings = JsonConvert.DeserializeObject<List<Domain.Models.Rating?>>(serializedRatingList);

				ratingDtos = _mapper.Map<List<RatingDTO>>(ratings);
			}
			else
			{
				ratings = await _ratingRepository.GetAllAsync();
				ratingDtos = _mapper.Map<List<RatingDTO>>(ratings);

				serializedRatingList = JsonConvert.SerializeObject(ratings);
				ratingDistributedList = Encoding.UTF8.GetBytes(serializedRatingList);
				var options = new DistributedCacheEntryOptions()
					.SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
					.SetSlidingExpiration(TimeSpan.FromMinutes(2));
				await _cache.SetAsync(cacheKey, ratingDistributedList, options);
			}

			return ratingDtos;
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
