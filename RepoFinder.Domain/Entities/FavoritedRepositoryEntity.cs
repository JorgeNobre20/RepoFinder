namespace RepoFinder.Domain.Entities
{
    public class FavoritedRepositoryEntity
    {
        public long Id { get; set; }
        public long GithubRepositoryId { get; set; }
        public string RepositoryName { get; set; } = string.Empty;
    }
}
