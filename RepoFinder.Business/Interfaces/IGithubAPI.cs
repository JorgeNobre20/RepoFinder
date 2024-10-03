using RepoFinder.Business.DTOs;
using RepoFinder.Domain.Entities;

namespace RepoFinder.Business.Interfaces
{
    public interface IGithubAPI
    {
        Task<ActionResult<GithubRepositoryEntity>> GetUserRepositories(string username);
        Task<ActionResult<GithubRepositoryEntity>> GetRepositoryByUsernameAndName(string username, string repositoryName);
        Task<ActionResult<PaginatedResult<GithubRepositoryEntity>>> SearchRepositoriesByName(string searchText, int page, int itemsPerPage);
    }
}
