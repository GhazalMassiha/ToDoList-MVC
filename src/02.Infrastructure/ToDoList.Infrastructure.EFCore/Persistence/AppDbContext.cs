using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Core.CategoryAgg.Entities;
using ToDoList.Domain.Core.ToDoItemAgg.Entities;
using ToDoList.Domain.Core.UserAgg.Entities;
using ToDoList.Infrastructure.EFCore.Configurations;

namespace ToDoList.Infrastructure.EFCore.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
        }
    }
}
