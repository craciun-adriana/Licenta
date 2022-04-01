using LicentaAPI.AppServices.Films.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;

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
            film.ID = Guid.NewGuid().ToString();
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

        public void DeleteBook(string idFilm)
        {
            var film = _filmRepo.GetById(idFilm);
            if (film != null)
            {
                _filmRepo.Delete(film);
            }
        }

        public IEnumerable<Film> FindFilmByTitle(string title)
        {
            return _filmRepo.FindFilmByTitle(title);
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return _filmRepo.GetAll();
        }

        public Film GetFilmById(string idFilm)
        {
            return _filmRepo.GetById(idFilm);
        }

        public FilmUpdateResult UpdateFilm(FilmUpdate filmUpdate)
        {
            var film = GetFilmById(filmUpdate.ID);
            if (film == null)
            {
                return new FilmUpdateResult
                {
                    Error = "Film not found.",
                    FilmUpdate = null
                };
            }

            _mapper.Map(filmUpdate, film);
            _filmRepo.Update(film);

            return new FilmUpdateResult
            {
                Error = "",
                FilmUpdate = film
            };
        }
    }
}