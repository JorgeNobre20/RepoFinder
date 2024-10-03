namespace RepoFinder.Domain.Entities
{
    public class GithubRepositoryEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Language { get; set; } = string.Empty;
        public DateTimeOffset UpdatedAt { get; set; }
        public GithubUserEntity? Owner { get; set; }
    }
}
