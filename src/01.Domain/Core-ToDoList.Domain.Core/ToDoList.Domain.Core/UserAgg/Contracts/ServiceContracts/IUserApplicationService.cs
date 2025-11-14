using ToDoList.Domain.Core._common;
using ToDoList.Domain.Core.UserAgg.DTOs;

namespace ToDoList.Domain.Core.UserAgg.Contracts.ServiceContracts
{
    public interface IUserApplicationService
    {
        public Result<UserDto> Login(string userName, string password);
        public Result<bool> Register(UserCreateDto createUserDto);
    }
}
