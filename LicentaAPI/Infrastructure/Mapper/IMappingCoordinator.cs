using System.Collections.Generic;

namespace LicentaAPI.Infrastructure.Mapper
{
    /// <summary>
    /// Interface providing contracts for mapping.
    /// </summary>
    public interface IMappingCoordinator
    {
        /// <summary>
        /// Maps an object to another object.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TDest">The destination type.</typeparam>
        /// <param name="source">The object to map.</param>
        /// <returns>The mapped object.</returns>
        TDest Map<TSource, TDest>(TSource source);

        /// <summary>
        /// Maps an enumeration of objects to another enumeration of objects.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TDest">The destination type.</typeparam>
        /// <param name="source">The enumeration to map.</param>
        /// <returns>The mapped enumeration.</returns>
        IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source);

        /// <summary>
        /// Maps an object to another object.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TDest">The destination type.</typeparam>
        /// <param name="source">The object to map.</param>
        /// <param name="dest">The mapping destination object.</param>
        /// <returns>The mapped object.</returns>
        TDest Map<TSource, TDest>(TSource source, TDest dest);
    }
}