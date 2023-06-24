using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TKS.Core.Models;

namespace TKS.Datastore.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categorys { get; set; } = default!;
        public DbSet<PhotoEntity> ProductPhotos { get; set; } = default!;
        public DbSet<FolderEntity> ProductPhotoFolders { get; set; } = default!;


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
