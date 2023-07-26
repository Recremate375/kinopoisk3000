using AutoMapper;
using Identity.Domain.DTO;
using Identity.Domain.Models;

namespace Identity.Domain.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserDTO>().ReverseMap();
			CreateMap<User, CreateUserDTO>().ReverseMap();
			CreateMap<Role, RoleDTO>().ReverseMap();
		}
	}
}
