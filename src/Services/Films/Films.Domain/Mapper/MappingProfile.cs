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
			CreateMap<FilmType, FilmTypeDTO>().ReverseMap();
			CreateMap<Film, CreateFilmDTO>().ReverseMap();
			CreateMap<FilmType, CreateTypeDTO>().ReverseMap();
			CreateMap<Film, UpdateFilmDTO>().ReverseMap();
		}
	}
}
