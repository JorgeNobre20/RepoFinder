using AutoMapper;
using RepoFinder.Business.DTOs;
using RepoFinder.Business.Interfaces;
using RepoFinder.Domain.Entities;
using Newtonsoft.Json;
using System.Net;
using RepoFinder.Infra.DTOs;

namespace RepoFinder.Infra.Services
{
    public class GithubAPI : IGithubAPI
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public GithubAPI(IMapper mapper, HttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }


        public async Task<ActionResult<GithubRepositoryEntity>> GetRepositoryByUsernameAndName(string username, string repositoryName)
        {
            try
            {
                string getRepositoryByUsernameAndNameURI = $"repos/{username}/{repositoryName}";

                var result = await _httpClient.GetAsync(getRepositoryByUsernameAndNameURI);
                var contentAsJson = await result.Content.ReadAsStringAsync();

                if (result.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    return new ActionResult<GithubRepositoryEntity>()
                    {
                        Message = $"Repositório do usuário não encontrado",
                        IsValid = false
                    };
                }

                if (!result.IsSuccessStatusCode)
                {
                    return new ActionResult<GithubRepositoryEntity>()
                    {
                        Message = $"Erro ao buscar repositório do usuário na API do GitHub",
                        IsValid = false
                    };
                }

                var apiRepository = JsonConvert.DeserializeObject<GitHubRepository>(contentAsJson);

                if (apiRepository is null)
                {
                    return new ActionResult<GithubRepositoryEntity>()
                    {
                        Message = $"Erro ao mapear dados retornados da API do Github",
                        IsValid = false
                    };
                }

                var repository = _mapper.Map<GitHubRepository, GithubRepositoryEntity>(apiRepository);

                return new ActionResult<GithubRepositoryEntity>()
                {
                    IsValid = true,
                    Result = repository
                };
            }
            catch 
            {
                var errorMessage = $"Erro ao buscar repositório {repositoryName} do usuário {username}";

                return new ActionResult<GithubRepositoryEntity>()
                {
                    Message = errorMessage,
                    IsValid = false
                };
            }
        }

        public async Task<ActionResult<GithubRepositoryEntity>> GetUserRepositories(string username)
        {
            try
            {
                string repositoriesURI = $"users/{username}/repos";

                var result = await _httpClient.GetAsync(repositoriesURI);
                var contentAsJson = await result.Content.ReadAsStringAsync();

                if (result.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    return new ActionResult<GithubRepositoryEntity>()
                    {
                        Message = $"Repositórios do usuário {username} não foram encontrados",
                        IsValid = false
                    };
                }

                if (!result.IsSuccessStatusCode)
                {
                    return new ActionResult<GithubRepositoryEntity>()
                    {
                        Message = $"Erro ao consultar repositórios do usuário {username} na API do GitHub",
                        IsValid = false
                    };
                }

                var apiRepositories = JsonConvert.DeserializeObject<List<GitHubRepository>>(contentAsJson);

                if (apiRepositories is null)
                {
                    return new ActionResult<GithubRepositoryEntity>()
                    {
                        Message = $"Erro ao mapear dados retornados da API do Github",
                        IsValid = false
                    };
                }

                List<GithubRepositoryEntity> repositories = _mapper.Map<List<GitHubRepository>, List<GithubRepositoryEntity>>(apiRepositories);

                return new ActionResult<GithubRepositoryEntity>()
                {
                    IsValid = true,
                    Results = repositories
                };
            }
            catch
            {
                var errorMessage = $"Erro ao fazer consulta dos repositórios do usuário {username}";

                return new ActionResult<GithubRepositoryEntity>()
                {
                    Message = errorMessage,
                    IsValid = false
                };
            }
        }

        public async Task<ActionResult<PaginatedResult<GithubRepositoryEntity>>> SearchRepositoriesByName(string search, int page, int itemsPerPage)
        {
            try
            {
                string repositoriesURI = $"search/repositories?q={search}&page={page}&per_page={itemsPerPage}";

                var result = await _httpClient.GetAsync(repositoriesURI);
                var contentAsJson = await result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode)
                {
                    return new ActionResult<PaginatedResult<GithubRepositoryEntity>>()
                    {
                        Message = $"Erro ao buscar repositórios na API do Github",
                        IsValid = false
                    };
                }

                var repositorySearchResult = JsonConvert.DeserializeObject<RepositorySearchResult>(contentAsJson);

                if (repositorySearchResult is null)
                {
                    return new ActionResult<PaginatedResult<GithubRepositoryEntity>>()
                    {
                        Message = $"Erro ao mapear dados retornados da API do Github",
                        IsValid = false
                    };
                }

                var totalPages = Math.Ceiling((decimal) repositorySearchResult.TotalCount / itemsPerPage);
                List<GithubRepositoryEntity> repositories = _mapper.Map<List<GitHubRepository>, List<GithubRepositoryEntity>>(repositorySearchResult.Items);

                var paginatedResult = new PaginatedResult<GithubRepositoryEntity>
                {
                    Items = repositories,
                    Count = repositories.Count,
                    ItemsPerPage = itemsPerPage,
                    TotalPages = Convert.ToInt32(totalPages)
                };

                return new ActionResult<PaginatedResult<GithubRepositoryEntity>>()
                {
                    IsValid = true,
                    Result = paginatedResult
                };
            }
            catch
            {
                var errorMessage = $"Erro ao fazer consulta dos repositórios por nome";

                return new ActionResult<PaginatedResult<GithubRepositoryEntity>>()
                {
                    Message = errorMessage,
                    IsValid = false
                };
            }
        }
    }
}
