using Microsoft.EntityFrameworkCore;
using ProniaOnionAB104.Domain.Entities;
using System.Reflection;

namespace ProniaOnionAB104.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Tag>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entites = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in entites)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.ModifiedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedAt = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
