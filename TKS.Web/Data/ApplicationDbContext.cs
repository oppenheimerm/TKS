using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TKS.Web.Models;

namespace TKS.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<PhotoEntity> ProductPhoto { get; set; } = default!;
        public DbSet<FolderEntity> ProductPhotoFolder { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<PhotoEntity>().ToTable("ProductPhoto");
            modelBuilder.Entity<FolderEntity>().ToTable("Folder");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoyCode).IsUnique();
            });
        }
    }
}