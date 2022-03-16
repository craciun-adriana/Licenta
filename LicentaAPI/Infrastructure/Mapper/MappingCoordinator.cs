﻿using AutoMapper;
using LicentaAPI.AppServices.Books.Models;
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
                cfg.CreateMap<BookCreate, Book>()
                    .ForMember(dest => dest.ID, opt => opt.Ignore());
            });
        }

        /// <inheritdoc />
        public TDest Map<TSource, TDest>(TSource source)
        {
            return Mapper.Map<TSource, TDest>(source);
        }

        /// <inheritdoc />
        public IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(source);
        }

        /// <inheritdoc />
        public TDest Map<TSource, TDest>(TSource source, TDest dest)
        {
            return Mapper.Map(source, dest);
        }
    }
}