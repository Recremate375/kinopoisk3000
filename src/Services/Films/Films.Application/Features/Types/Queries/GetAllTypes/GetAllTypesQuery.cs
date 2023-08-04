using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Types.Queries.GetAllTypes
{
	public class GetAllTypesQuery : IRequest<List<FilmTypeDTO>>
	{
	}
}
