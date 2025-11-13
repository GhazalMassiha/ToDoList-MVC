using ToDoList.Domain.Core.UserAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.UserAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.UserAgg.DTOs;

namespace ToDoList.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Create(UserCreateDto createUserDto)
        {
            return _userRepository.Create(createUserDto);
        }

        public bool UsernameAlreadyExists(string username)
        {
            return _userRepository.UsernameAlreadyExists(username);
        }

        public UserDto? GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public UserDto? GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public void Save()
        {
            _userRepository.Save();
        }
    }
}
