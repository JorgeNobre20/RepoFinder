using AutoMapper;
using RepoFinder.Domain.Entities;
using RepoFinder.Infra.DTOs;

namespace RepoFinder.Api.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Owner, GithubUserEntity>();
            CreateMap<GitHubRepository, GithubRepositoryEntity>();
        }
    }
}
