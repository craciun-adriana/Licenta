namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Query to be used by repositories.
    /// </summary>
    public class PaginationQuery
    {
        /// <summary>
        /// The number of entities that are skipped in the result.
        /// </summary>
        public int Skip { get; }

        /// <summary>
        /// The maxim number of entities that can be returned in the result.
        /// </summary>
        public int Take { get; }

        /// <summary>
        /// The filter that will be applied.
        /// </summary>
        /// <example>"Title = \"Eternals\""</example>
        public string Filter { get; }

        /// <summary>
        /// The property by which entities will be ordered by.
        /// </summary>
        public string OrderBy { get; }

        /// <summary>
        /// If the ordering should be ascending or descending.
        /// </summary>
        public bool OrderByDescending { get; }

        public PaginationQuery(int skip = 0, int take = 1000, string filter = "", string orderBy = "", bool orderByDescending = false)
        {
            Skip = skip;
            Take = take;
            Filter = filter;
            OrderBy = orderBy;
            OrderByDescending = orderByDescending;
        }
    }
}