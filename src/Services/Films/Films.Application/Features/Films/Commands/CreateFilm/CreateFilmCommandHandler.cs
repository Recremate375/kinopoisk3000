using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Models;
using MediatR;

namespace Films.Application.Features.Films.Commands.CreateFilm
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Film>
    {
        private readonly IFilmCommandRepository _filmCommandRepository;
        private readonly ITypeQueryRepository _typeQueryRepository;
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IFilmCommandRepository filmCommandRepository, ITypeQueryRepository typeQueryRepository, IMapper mapper)
        {
            _filmCommandRepository = filmCommandRepository;
            _typeQueryRepository = typeQueryRepository;
            _mapper = mapper;
        }

        public async Task<Film> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var film = _mapper.Map<Film>(request.CreateFilmDTO);

            await _filmCommandRepository.CreateAsync(film);
            await _filmCommandRepository.SaveAsync();

            return film;
        }
    }
}
