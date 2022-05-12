using AutoMapper;
using LicentaAPI.AppServices.Appointments.Model;
using LicentaAPI.AppServices.Books.Models;
using LicentaAPI.AppServices.Films.Models;
using LicentaAPI.AppServices.Friendships.Model;
using LicentaAPI.AppServices.GroupMembers.Model;
using LicentaAPI.AppServices.Groups.Model;
using LicentaAPI.AppServices.ReviewBooks.Model;
using LicentaAPI.AppServices.ReviewFilms.Model;
using LicentaAPI.AppServices.ReviewSerieses.Model;
using LicentaAPI.AppServices.Serieses.Models;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Infrastructure.Mapper
{
    /// <summary>
    /// Specific implementation of <see cref="IMappingCoordinator"/>.
    /// </summary>
    public class MappingCoordinator : IMappingCoordinator
    {
        private readonly IMapper _mapper;
        protected IMapper Mapper => _mapper;

        public MappingCoordinator()
        {
            var config = InitializeMapping();
            _mapper = config.CreateMapper();
        }

        private MapperConfiguration InitializeMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppointmentCreateRequest, AppointmentCreate>();
                cfg.CreateMap<AppointmentCreate, Appointment>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<BookCreateRequest, BookCreate>();
                cfg.CreateMap<BookCreate, Book>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<FilmCreateRequest, FilmCreate>();
                cfg.CreateMap<FilmCreate, Film>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<FriendshipCreate, Friendship>()
                    .ForMember(dest => dest.Status, opt => opt.Ignore())
                    .ForMember(dest => dest.LastUpdate, opt => opt.Ignore())
                    .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<GroupCreateRequest, GroupCreate>();
                cfg.CreateMap<GroupCreate, Group>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<GroupMemberCreateRequest, GroupMemberCreate>();
                cfg.CreateMap<GroupMemberCreate, GroupMember>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<ReviewBooksCreateRequest, ReviewBookCreate>();
                cfg.CreateMap<ReviewBookCreate, ReviewBook>()
                .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<ReviewFilmsCreateRequest, ReviewFilmCreate>();
                cfg.CreateMap<ReviewFilmCreate, ReviewFilm>()
                .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<ReviewSeriesCreateRequest, ReviewSeriesCreate>();
                cfg.CreateMap<ReviewSeriesCreate, ReviewSeries>()
                .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<SeriesCreateRequest, SeriesCreate>();
                cfg.CreateMap<SeriesCreate, Series>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
            });
        }

        /// <inheritdoc/>
        public TDest Map<TSource, TDest>(TSource source)
        {
            return Mapper.Map<TSource, TDest>(source);
        }

        /// <inheritdoc/>
        public IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(source);
        }

        /// <inheritdoc/>
        public TDest Map<TSource, TDest>(TSource source, TDest dest)
        {
            return Mapper.Map(source, dest);
        }
    }
}