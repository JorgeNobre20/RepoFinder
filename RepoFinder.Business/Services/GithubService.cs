using RepoFinder.Business.DTOs;
using RepoFinder.Business.Exceptions;
using RepoFinder.Business.Interfaces;
using RepoFinder.Domain.Entities;

namespace RepoFinder.Business.Services
{
    public class GithubService : IGitHubService
    {
        private IGithubAPI _githubAPI;

        public GithubService(IGithubAPI githubAPI)
        {
            _githubAPI = githubAPI;
        }


        public async Task<PaginatedResult<GithubRepositoryEntity>> SearchRepositoriesByName(string searchText, int page, int itemsPerPage)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                throw new InvalidInfoException("Texto buscado não pode ser vazio nem nulo");
            }

            ActionResult<PaginatedResult<GithubRepositoryEntity>> apiSearchResult = await _githubAPI.SearchRepositoriesByName(searchText, page, itemsPerPage);

            if (!apiSearchResult.IsValid || apiSearchResult.Result is null)
            {
                throw new InvalidResultException(apiSearchResult.Message);
            }

            var result = new PaginatedResult<GithubRepositoryEntity>()
            {
                Count = apiSearchResult.Result.Count,
                Items = apiSearchResult.Result.Items,
                ItemsPerPage = apiSearchResult.Result.ItemsPerPage,
                TotalPages = apiSearchResult.Result.TotalPages
            };

            return result;
        }

        public async Task<GithubRepositoryEntity?> GetRepositoryDetails(string githubUsername, string githubRepositoryName)
        {
            ActionResult<GithubRepositoryEntity> result = await _githubAPI.GetRepositoryByUsernameAndName(githubUsername, githubRepositoryName);

            if (!result.IsValid)
            {
                throw new InvalidResultException(result.Message);
            }

            if (result.Result is null)
            {
                throw new NoContentException($"Repositório não encontrado");
            }

            return result.Result;
        }

        public async Task<IList<GithubRepositoryEntity>> GetUserRepositories(string githubUsername)
        {
            ActionResult<GithubRepositoryEntity> result = await _githubAPI.GetUserRepositories(githubUsername);

            if (!result.IsValid)
            {
                throw new InvalidResultException(result.Message);
            }

            if (result.Results is null)
            {
                throw new NoContentException($"Repositórios de {githubUsername} não foram encontrados");
            }

            return result.Results;
        }
    }
}
