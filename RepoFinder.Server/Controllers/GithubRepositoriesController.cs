using RepoFinder.Business.Interfaces;
using RepoFinder.Domain.Entities;
using RepoFinder.Infra.Data.Database;
using Microsoft.EntityFrameworkCore;
using RepoFinder.Business.DTOs;
using AspNetMvc = Microsoft.AspNetCore.Mvc;
using RepoFinder.Api.DTOs;

namespace RepoFinder.Api.Controllers
{
    [AspNetMvc.ApiController]
    [AspNetMvc.Route("api/github/repositories")]
    public class GithubRepositoryController : AspNetMvc.ControllerBase
    {
        private readonly IGitHubService _githubService;
        private readonly ApplicationDbContext _applicationDbContext;

        public GithubRepositoryController(IGitHubService githubService, ApplicationDbContext applicationDbContext)
        {
            _githubService = githubService;
            _applicationDbContext = applicationDbContext;
        }

        [AspNetMvc.HttpGet("{githubUsername}")]
        public async Task<AspNetMvc.ActionResult<IList<GithubRepositoryEntity>>> GetAllUserRepositories(string githubUsername)
        {
            var repositories = await _githubService.GetUserRepositories(githubUsername);
            return Ok(repositories);
        }

        [AspNetMvc.HttpGet("{githubUsername}/{githubRepositoryName}")]
        public async Task<AspNetMvc.ActionResult<GithubRepositoryEntity>> GetRepositoryDetails(string githubUsername, string githubRepositoryName)
        {
            var repository = await _githubService.GetRepositoryDetails(githubUsername, githubRepositoryName);
            return Ok(repository);
        }

        [AspNetMvc.HttpGet("search")]
        public async Task<AspNetMvc.ActionResult<PaginatedResult<GithubRepositoryEntity>>> SearchRepositoryByName(RepositorySearch queryParams)
        {
            var repository = await _githubService.SearchRepositoriesByName(
                searchText: queryParams.Search,
                page: queryParams.Page,
                itemsPerPage: queryParams.ItemsPerPage
            );

            return Ok(repository);
        }


        [AspNetMvc.HttpPost("favorited")]
        public async Task<AspNetMvc.ActionResult> SaveFavoritedRepository()
        {
            _applicationDbContext.FavoritedRepositories.Add(new FavoritedRepositoryEntity
            {
                GithubRepositoryId = 1,
                RepositoryName = "Nome do repositório"
            });

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Repostório salvo com sucesso"
            });
        }

        [AspNetMvc.HttpGet("favorited")]
        public async Task<AspNetMvc.ActionResult> GetFavoritedRepositories()
        {
            var result = await _applicationDbContext.FavoritedRepositories.ToListAsync();

            return Ok(result);
        }

    }
}
