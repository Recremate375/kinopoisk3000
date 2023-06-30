using AutoMapper;
using Films.Domain.DTO;
using Films.Domain.Models;

namespace Films.Domain.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Film, FilmDTO>().ReverseMap();
			CreateMap<Models.Type, TypeDTO>().ReverseMap();
			CreateMap<Film, CreateFilmDTO>().ReverseMap();
			CreateMap<Models.Type, CreateTypeDTO>().ReverseMap();
		}
	}
}
