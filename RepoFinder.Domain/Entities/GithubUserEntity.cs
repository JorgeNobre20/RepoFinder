namespace RepoFinder.Domain.Entities
{
    public class GithubUserEntity
    {
        public long Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public Uri? AvatarUrl { get; set; }
        public Uri? HtmlUrl { get; set; }
    }
}
