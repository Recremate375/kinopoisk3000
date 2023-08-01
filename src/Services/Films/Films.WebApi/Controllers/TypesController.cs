using Films.Application.Features.Types.Commands.CreateType;
using Films.Application.Features.Types.Commands.DeleteType;
using Films.Application.Features.Types.Commands.UpdateType;
using Films.Application.Features.Types.Queries.GetAllTypes;
using Films.Application.Features.Types.Queries.GetTypeById;
using Films.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Films.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TypesController : ControllerBase
	{
		private readonly ISender _mediator;

		public TypesController(ISender mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetTypesListAsync()
		{
			var types = await _mediator.Send(new GetAllTypesQuery());

			return Ok(types);
		}

		[HttpGet]
		[Route("{typeId:int}")]
		public async Task<IActionResult> GetTypeByIdAsync([FromRoute] int typeId)
		{
			var type = await _mediator.Send(new GetTypeByIdQuery() { Id = typeId });

			return Ok(type);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTypeAsync([FromBody] CreateTypeDTO createTypeDTO)
		{
			await _mediator.Send(new CreateTypeCommand() { Type = createTypeDTO });

			return Created("GetTypeByIdAsync", createTypeDTO);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFilmType([FromBody] FilmTypeDTO typeDTO)
		{
			await _mediator.Send(new UpdateTypeCommand() { Type = typeDTO });

			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteFilmType(int typeId)
		{
			await _mediator.Send(new DeleteTypeCommand() { Id = typeId });

			return Ok();
		}
	}
}
