using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Infrastructure.EFCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .HasMaxLength(50);

            builder.Property(u => u.Password)
                .HasMaxLength(100);

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GetDate()")
                .ValueGeneratedOnAdd();

            builder.HasMany(u => u.ToDoItems)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
                new User
                {
                    Id = 1,
                    Username = "user1",
                    Password = "1234",
                },
                new User
                {
                    Id = 2,
                    Username = "user2",
                    Password = "1234",
                },
                new User
                {
                    Id = 3,
                    Username = "user3",
                    Password = "1234",
                }
                );

        }
    }
}
