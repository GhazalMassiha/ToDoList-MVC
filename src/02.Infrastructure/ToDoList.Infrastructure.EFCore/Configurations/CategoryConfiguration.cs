using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Core.CategoryAgg.Entities;

namespace ToDoList.Infrastructure.EFCore.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50);

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GetDate()")
                .ValueGeneratedOnAdd();

            builder.HasMany(c => c.ToDoItems)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Category { Id = 1, Name = "شخصی"},
                new Category { Id = 2, Name = "کاری"},
                new Category { Id = 3, Name = "دانشگاهی"},
                new Category { Id = 4, Name = "سایر"}
            );
        }
    }
}
