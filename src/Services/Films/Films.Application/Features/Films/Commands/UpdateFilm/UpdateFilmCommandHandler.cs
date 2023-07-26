using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using Films.Domain.Models;
using MediatR;

namespace Films.Application.Features.Films.Commands.UpdateFilm
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand>
    {
        private readonly IFilmCommandRepository _filmCommandRepository;
        private readonly IFilmQueryRepository _filmQueryRepository;
        private readonly ITypeQueryRepository _typeQueryRepository;
        private readonly IMapper _mapper;

        public UpdateFilmCommandHandler(IFilmCommandRepository filmCommandRepository,
            IFilmQueryRepository filmQueryRepository, IMapper mapper, ITypeQueryRepository typeQueryRepository)
        {
            _filmCommandRepository = filmCommandRepository;
            _filmQueryRepository = filmQueryRepository;
            _mapper = mapper;
            _typeQueryRepository = typeQueryRepository;
        }

        public async Task Handle(UpdateFilmCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _filmQueryRepository.GetByIdAsync(request.FilmId) 
                ?? throw new NotFoundException($"Entity {request.UpdateFilm.FilmName} not found!");

            entity = _mapper.Map<Film>(request.UpdateFilm);

            _filmCommandRepository.Update(entity);
            await _filmCommandRepository.SaveAsync();
        }
    }
}
