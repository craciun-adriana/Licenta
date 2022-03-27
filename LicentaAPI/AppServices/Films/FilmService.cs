using LicentaAPI.AppServices.Films.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;

namespace LicentaAPI.AppServices.Films
{
    /// <summary>
    /// Concrete implementation of <see cref="IFilmService"/>.
    /// </summary>
    public class FilmService : IFilmService
    {
        private IFilmRepo _filmRepo;
        private IMappingCoordinator _mapper;

        public FilmService(IFilmRepo filmRepo, IMappingCoordinator mapper)
        {
            _filmRepo = filmRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Film CreateFilm(FilmCreate filmCreate)
        {
            var film = _mapper.Map<FilmCreate, Film>(filmCreate);
            try
            {
                _filmRepo.Add(film);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return film;
        }
    }
}