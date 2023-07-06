using Films.Application.Types.Commands.CreateType;
using Films.Application.Types.Commands.DeleteType;
using Films.Application.Types.Commands.UpdateType;
using Films.Application.Types.Queries.GetAllTypes;
using Films.Application.Types.Queries.GetTypeById;
using Films.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace Films.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TypesController : ControllerBase
	{
		private readonly ISender mediator;

		public TypesController(ISender mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet]
		public async Task<List<FilmTypeDTO>> GetTypesListAsync()
		{
			var types = await mediator.Send(new GetAllTypesQuery());

			return types;
		}
		[HttpGet]
		[Route("{typeId:int}")]
		public async Task<FilmTypeDTO> GetTypeByIdAsync([FromRoute]int typeId)
		{
			var type = await mediator.Send(new GetTypeByIdQuery() { Id = typeId });

			return type;
		}

		[HttpPost]
		public async Task<ActionResult> CreateTypeAsync([FromBody] CreateTypeDTO createTypeDTO)
		{
			await mediator.Send(new CreateTypeCommand() { Type = createTypeDTO });

			return StatusCode(201);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateFilmType([FromBody] FilmTypeDTO typeDTO)
		{
			await mediator.Send(new UpdateTypeCommand() { Type = typeDTO });

			return StatusCode(200);
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteFilmType(int typeId)
		{
			await mediator.Send(new DeleteTypeCommand() { Id = typeId });

			return StatusCode(200);
		}
	}
}
