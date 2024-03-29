﻿using AutoMapper;
using LicentaAPI.AppServices.Appointments.Model;
using LicentaAPI.AppServices.Books.Models;
using LicentaAPI.AppServices.Films.Models;
using LicentaAPI.AppServices.Friendships.Model;
using LicentaAPI.AppServices.GroupMembers.Model;
using LicentaAPI.AppServices.Groups.Model;
using LicentaAPI.AppServices.Messages.Model;
using LicentaAPI.AppServices.Models;
using LicentaAPI.AppServices.ReviewBooks.Model;
using LicentaAPI.AppServices.ReviewFilms.Model;
using LicentaAPI.AppServices.ReviewSerieses.Model;
using LicentaAPI.AppServices.Serieses.Models;
using LicentaAPI.AppServices.Users.Models;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

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
                cfg.CreateMap<AppUser, PublicUserDetails>();

                cfg.CreateMap<AppointmentCreateRequest, AppointmentCreate>();
                cfg.CreateMap<AppointmentCreate, Appointment>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<BookCreateRequest, BookCreate>();
                cfg.CreateMap<BookCreate, Book>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<UpdateBookRequest, BookUpdate>();
                cfg.CreateMap<BookUpdate, Book>();

                cfg.CreateMap<FilmCreateRequest, FilmCreate>();
                cfg.CreateMap<FilmCreate, Film>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<Film, FilmDTO>();
                cfg.CreateMap<FilmDTO, Film>();
                cfg.CreateMap<UpdateFilmRequest, FilmUpdate>();
                cfg.CreateMap<FilmUpdate, Film>();

                cfg.CreateMap<FriendshipCreateRequest, FriendshipCreate>()
                    .ForMember(dest => dest.IdSender, opt => opt.Ignore());
                cfg.CreateMap<FriendshipCreate, Friendship>()
                    .ForMember(dest => dest.Status, opt => opt.Ignore())
                    .ForMember(dest => dest.LastUpdate, opt => opt.Ignore())
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<Friendship, FriendshipDTO>();

                cfg.CreateMap<GroupCreateRequest, GroupCreate>();
                cfg.CreateMap<GroupCreate, Group>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore())
                    .ForMember(dest => dest.LastMessageTimestamp, opt => opt.Ignore());

                cfg.CreateMap<GroupMemberCreateRequest, GroupMemberCreate>();
                cfg.CreateMap<GroupMemberCreate, GroupMember>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());

                cfg.CreateMap<MessageCreateRequest, MessageCreate>()
                    .ForMember(dest => dest.IdSender, opt => opt.Ignore());
                cfg.CreateMap<MessageCreate, Message>()
                    .ForMember(dest => dest.SendTime, opt => opt.Ignore())
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<Message, MessageDTO>();

                cfg.CreateMap<ReviewCreateRequest, ReviewBookCreate>()
                    .ForMember(dest => dest.IdUser, opt => opt.Ignore())
                    .ForMember(dest => dest.IdBook, opt => opt.MapFrom(src => src.IdResource));
                cfg.CreateMap<ReviewBookCreate, ReviewBook>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<ReviewBook, ReviewBookDTO>()
                .ForMember(dest => dest.Book, opt => opt.Ignore());

                cfg.CreateMap<ReviewCreateRequest, ReviewFilmCreate>()
                    .ForMember(dest => dest.IdUser, opt => opt.Ignore())
                    .ForMember(dest => dest.IdFilm, opt => opt.MapFrom(src => src.IdResource));
                cfg.CreateMap<ReviewFilmCreate, ReviewFilm>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<ReviewFilm, ReviewFilmDTO>()
                .ForMember(dest => dest.Film, opt => opt.Ignore());

                cfg.CreateMap<ReviewCreateRequest, ReviewSeriesCreate>()
                    .ForMember(dest => dest.IdUser, opt => opt.Ignore())
                    .ForMember(dest => dest.IdSeries, opt => opt.MapFrom(src => src.IdResource));
                cfg.CreateMap<ReviewSeriesCreate, ReviewSeries>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<ReviewSeries, ReviewSeriesDTO>()
                .ForMember(dest => dest.Series, opt => opt.Ignore());

                cfg.CreateMap<SeriesCreateRequest, SeriesCreate>();
                cfg.CreateMap<SeriesCreate, Series>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<Series, SeriesDTO>();
                cfg.CreateMap<SeriesDTO, Series>();
                cfg.CreateMap<UpdateSeriesRequest, SeriesUpdate>();
                cfg.CreateMap<SeriesUpdate, Series>();

                cfg.CreateMap<UpdateUserRequest, UserUpdate>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<UserUpdate, AppUser>();
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