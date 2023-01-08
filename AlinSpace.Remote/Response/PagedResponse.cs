namespace AlinSpace.Remote
{
    /// <summary>
    /// Respresents the paged response.
    /// </summary>
    /// <typeparam name="T">Type of the value.</typeparam>
    public class PagedResponse<T> : Response<Paged<T>>
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        public IEnumerable<T> Items => Item?.Items ?? Enumerable.Empty<T>();
    }
}
