using Microsoft.AspNetCore.Mvc;

namespace RepoFinder.Api.DTOs
{
    public class RepositorySearch
    {
        [FromQuery(Name = "search")]
        public string Search { get; set; } = string.Empty;

        [FromQuery(Name = "items_per_page")]
        public int ItemsPerPage { get; set; } = 5;

        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;
    }
}
