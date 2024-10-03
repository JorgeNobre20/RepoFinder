using RepoFinder.Business.DTOs;
using RepoFinder.Domain.Entities;

namespace RepoFinder.Business.Interfaces
{
    public interface IGitHubService
    {
        Task<IList<GithubRepositoryEntity>> GetUserRepositories(string githubUsername);
        Task<GithubRepositoryEntity?> GetRepositoryDetails(string githubUsername, string githubRepositoryName);
        Task<PaginatedResult<GithubRepositoryEntity>> SearchRepositoriesByName(string searchText, int page, int itemsPerPage);
    }
}
