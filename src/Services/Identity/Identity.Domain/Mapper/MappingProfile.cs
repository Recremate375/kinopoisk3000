using AutoMapper;
using Identity.Domain.DTO;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
