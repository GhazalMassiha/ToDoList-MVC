using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Core.ToDoItemAgg.Entities;
using ToDoList.Domain.Core.UserAgg.Entities;

namespace ToDoList.Infrastructure.EFCore.Configurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Title)
                .HasMaxLength(200);

            builder.Property(i => i.CreatedAt)
                .HasDefaultValueSql("GetDate()")
                .ValueGeneratedOnAdd();

            builder.HasOne(b => b.User)
               .WithMany(u => u.ToDoItems)
               .HasForeignKey(b => b.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Category)
               .WithMany(u => u.ToDoItems)
               .HasForeignKey(b => b.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
               new ToDoItem
               {
                   Id = 1,
                   Title = "پروژه مکتب",
                   DueDate = new DateTime(1404 - 08 - 31),
                   CategoryId = 2,
                   UserId = 1,
                   IsCompleted = false
               },
               new ToDoItem
               {
                   Id = 2,
                   Title = "تحقیق درس 1 مبانی سیستم عامل",
                   DueDate = new DateTime(1404 - 07 - 31),
                   CategoryId = 3,
                   UserId = 1,
                   IsCompleted = false
               },
               new ToDoItem
               {
                   Id = 3,
                   Title = "تعویض روغن",
                   DueDate = new DateTime(1403 - 03 - 30),
                   CategoryId = 1,
                   UserId = 1,
                   IsCompleted = true
               },
               new ToDoItem
               {
                   Id = 4,
                   Title = "خرید مایحتاج",
                   DueDate = new DateTime(1404 - 09 - 30),
                   CategoryId = 1,
                   UserId = 1,
                   IsCompleted = false
               }
               );
        }
    }
}
