using ToDoList.Domain.Core.UserAgg.DTOs;
using ToDoList.Domain.Core.UserAgg.Entities;

namespace ToDoList.Domain.Core.UserAgg.Contracts.RepositoryContracts
{
    public interface IUserRepository
    {
        public int Create(UserCreateDto createUserDto);
        public bool UsernameAlreadyExists(string username);
        public UserDto? GetByUsername(string username);
        public UserDto? GetById(int userId);
        public void Save();
    }
}
