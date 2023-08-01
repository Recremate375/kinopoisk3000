using Films.Application.Features.Films.Commands.CreateFilm;
using Films.Application.Features.Films.Commands.DeleteFilm;
using Films.Application.Features.Films.Commands.UpdateFilm;
using Films.Application.Features.Films.Queries.GetAllFilms;
using Films.Application.Features.Films.Queries.GetFilmById;
using Films.Application.Features.Films.Queries.GetFilmByName;
using Films.Application.Features.Films.Queries.GetFilmsByProductionYear;
using Films.Application.Features.Films.Queries.GetFilmsByType;
using Films.Domain.DTO;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Films.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilmsController : ControllerBase
	{
		private readonly ISender _mediator;
		private readonly IPublishEndpoint _publishEndpoint;

		public FilmsController(ISender mediator, IPublishEndpoint publishEndpoint)
		{
			_mediator = mediator;
			_publishEndpoint = publishEndpoint;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllFilms()
		{
			var films = await _mediator.Send(new GetFilmsQuery());

			return Ok(films);
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<IActionResult> GetFilmById(int id)
		{
			var film = await _mediator.Send(new GetFilmByIdQuery() { FilmId = id });

			return Ok(film);
		}

		[HttpGet]
		[Route("{name:alpha}")]
		public async Task<IActionResult> GetFilmByName(string name)
		{
			var film = await _mediator.Send(new GetFilmByNameQuery() { FilmName = name });

			return Ok(film);
		}

		[HttpGet]
		[Route("{productionTime:DateTime}")]
		public async Task<IActionResult> GetFilmsByProductionYear(DateTime productionTime)
		{
			var film = await _mediator.Send(new GetFilmsByProductionYearQuery() { ProductionYear = productionTime });

			return Ok(film);
		}

		[HttpPost]
		[Route("getFilmsByType")]
		public async Task<IActionResult> GetFilmsByType(FilmTypeDTO typeName)
		{
			var films = await _mediator.Send(new GetFilmsByTypeQuery() { FilmTypeDTO = typeName });

			return Ok(films);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFilmAsync([FromBody] CreateFilmDTO createFilmDTO)
		{
			await _mediator.Send(new CreateFilmCommand() { CreateFilmDTO = createFilmDTO });

			return Created(nameof(GetFilmByName), createFilmDTO.FilmName);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFilmAsync([FromBody] UpdateFilmDTO updateFilmDTO, int id)
		{
			await _mediator.Send(new UpdateFilmCommand() { FilmId = id, UpdateFilm = updateFilmDTO });

			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteFilmAsync(int id)
		{
			await _mediator.Send(new DeleteFilmCommand() { Id = id });

			return Ok();
		}
	}
}
