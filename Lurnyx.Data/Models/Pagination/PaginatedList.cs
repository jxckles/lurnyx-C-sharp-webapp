using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data.Models
{
    /// <summary>
    /// A helper class to represent a paginated list of items.
    /// It contains the items for the current page and pagination metadata.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int PageNumber { get; }
        public int PageSize { get; } = 10;
        public int TotalPages { get; }
        public int TotalCount { get; }

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize; 
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        /// <summary>
        /// Creates a paginated list from an IQueryable source.
        /// This method executes the query against the database.
        /// </summary>
        /// <param name="source">The IQueryable source to paginate.</param>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A new instance of PaginatedList containing the results.</returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
