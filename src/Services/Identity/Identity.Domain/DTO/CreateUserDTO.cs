﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.DTO
{
	public class CreateUserDTO
	{
		public string Email { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}
