using AutoMapper;
using Rating.Domain.DTOs;
using Rating.Domain.Models;

namespace Rating.Domain.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Domain.Models.Rating, RatingDTO>().ReverseMap();
			CreateMap<Film, CreateFilmDTO>().ReverseMap();
			CreateMap<FilmToBrokerDTO, Film>().ReverseMap();
		}
	}
}
