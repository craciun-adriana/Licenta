﻿using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing generic contracts for a repository.
    /// </summary>
    /// <typeparam name="T">The type of the entity(class) to be stored in the database.</typeparam>
    public interface IGenericRepo<T> where T : class
    {
        /// <summary>
        /// Retrieves a single entity from the database with the given id.
        /// If no entity was found, null is returned.
        /// </summary>
        /// <param name="id">The id of the entity to be retrieved.</param>
        /// <returns>The found entity or null if it was not found.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when id is null or empty.</exception>
        T GetById(string id);

        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="entity">The entity that will be added to the database.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when entity is null.</exception>
        void Add(T entity);

        /// <summary>
        /// Updates an entity from the database.
        /// </summary>
        /// <param name="entity">The entity that will be updated from the database.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when entity is null.</exception>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity that will be deleted from the database.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when entity is null.</exception>
        void Delete(T entity);

        /// <summary>
        /// Filters entities from the database.
        /// </summary>
        /// <param name="paginationQuery">The query to be used.</param>
        /// <returns>All elements that match the query.</returns>
        IEnumerable<T> Filter(PaginationQuery paginationQuery);

        /// <summary>
        /// Gets all entities from database.
        /// </summary>
        /// <returns>All entities from database.</returns>
        IEnumerable<T> GetAll();
    }
}