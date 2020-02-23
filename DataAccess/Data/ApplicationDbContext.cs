using DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using Models.Entities;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ConnectionStringSettings _connectionStringSettings;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<ConnectionStringSettings> optionsAccessor)
            : base(options)
        {
            _connectionStringSettings = optionsAccessor.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringSettings.LocalDB);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>()
                .HasKey(a => a.Id);

            builder.Entity<ArticleCategory>()
                .HasKey(a => a.Id);
        }
    }
}
