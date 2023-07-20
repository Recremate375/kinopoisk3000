using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Features.Films.Queries.GetAllFilms
{
    public class GetFilmsQueryHandler : IRequestHandler<GetFilmsQuery, List<FilmDTO>>
    {
        private readonly IFilmQueryRepository _filmQueryRepository;

        public GetFilmsQueryHandler(IFilmQueryRepository filmQueryRepository)
        {
            _filmQueryRepository = filmQueryRepository;
        }

        public async Task<List<FilmDTO>> Handle(GetFilmsQuery request, CancellationToken cancellationToken)
        {
            var films = await _filmQueryRepository.GetAllAsync<FilmDTO>()
                ?? throw new NotFoundException($"Films not found");

            return films;
        }
    }
}
