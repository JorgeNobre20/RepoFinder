using Newtonsoft.Json;

namespace RepoFinder.Infra.DTOs
{
    public class RepositorySearchResult
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool HasIncompleteResulst { get; set; }

        [JsonProperty("items")]
        public List<GitHubRepository> Items { get; set; } = new List<GitHubRepository>();
    }
}
