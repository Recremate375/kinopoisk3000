using AutoMapper;
using Rating.Domain.DTOs;

namespace Rating.Domain.Mapper
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<Domain.Models.Rating, RatingDTO>().ReverseMap();
        }
    }
}
