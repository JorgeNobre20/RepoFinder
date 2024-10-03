namespace RepoFinder.Business.DTOs
{
    public class PaginatedResult<T> where T : class
    {
        public PaginatedResult() { }

        public int TotalPages { get; set; } = 1;
        
        public int Count { get; set; } = 0;

        public int ItemsPerPage = 10;

        public IList<T> Items { get; set; } = new List<T>();
    }
}
