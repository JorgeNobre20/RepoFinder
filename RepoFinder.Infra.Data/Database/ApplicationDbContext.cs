using RepoFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RepoFinder.Infra.Data.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FavoritedRepositoryEntity> FavoritedRepositories { get; set; }
    }
}
