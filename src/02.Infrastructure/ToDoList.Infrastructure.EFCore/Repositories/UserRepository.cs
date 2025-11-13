using ToDoList.Domain.Core.UserAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.UserAgg.DTOs;
using ToDoList.Domain.Core.UserAgg.Entities;
using ToDoList.Infrastructure.EFCore.Persistence;

namespace ToDoList.Infrastructure.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public int Create(UserCreateDto createUserDto)
        {
            var user = new User()
            {
                Username = createUserDto.Username,
                Password = createUserDto.Password,
            };

            _context.Add(user);
            Save();
            return user.Id;
        }

        public bool UsernameAlreadyExists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public UserDto? GetByUsername(string username)
        {
            return _context.Users.Where(x => x.Username == username).Select(u => new UserDto()
            {
                Id = u.Id,
                Username = u.Username,
            }).FirstOrDefault();
        }

        public UserDto? GetById(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).Select(u => new UserDto()
            {
                Id = u.Id,
                Username = u.Username,
            }).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
