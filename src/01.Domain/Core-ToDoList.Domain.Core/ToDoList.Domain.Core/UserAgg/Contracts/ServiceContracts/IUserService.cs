using ToDoList.Domain.Core.UserAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.UserAgg.DTOs;

namespace ToDoList.Domain.Core.UserAgg.Contracts.ServiceContracts
{
    public interface IUserService
    {
        public int Create(UserCreateDto createUserDto);
        public bool UsernameAlreadyExists(string username);
        public UserDto? GetByUsername(string username);
        public UserDto? GetById(int userId);
        public void Save();
    }
}
