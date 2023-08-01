﻿using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Films.Queries.GetAllFilms
{
	public class GetFilmsQuery : IRequest<List<FilmDTO>>
	{

	}
}
