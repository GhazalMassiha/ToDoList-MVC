using ToDoList.Domain.Core._common;
using ToDoList.Domain.Core.UserAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.UserAgg.DTOs;

namespace ToDoList.ApplicationService
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserService _userService;
        public UserApplicationService(IUserService userService)
        {
            _userService = userService;
        }

        public Result<UserDto> Login(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return Result<UserDto>.Failure("نام کاربری و رمز عبور الزامی است.");

            var user = _userService.GetByUsername(userName);

            if (user == null)
                return Result<UserDto>.Failure("نام کاربری یا رمز عبور اشتباه است.");


            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username
            };

            return Result<UserDto>.Success("خوش آمدید!", userDto);
        }

        public Result<bool> Register(UserCreateDto createUserDto)
        {

            if (string.IsNullOrWhiteSpace(createUserDto.Username) ||
                string.IsNullOrWhiteSpace(createUserDto.Password))
                return Result<bool>.Failure("نام کاربری و رمز عبور نمیتواند خالی باشد.");

            if (createUserDto.Username.Length < 4)
                return Result<bool>.Failure("نام کاربری باید حداقل ۴ کاراکتر باشد.");

            if (createUserDto.Password.Length < 4)
                return Result<bool>.Failure("رمز عبور باید حداقل 4 کاراکتر باشد.");


            if (_userService.UsernameAlreadyExists(createUserDto.Username))
                return Result<bool>.Failure("نام کاربری نمیتواند تکراری باشد.");

            _userService.Create(createUserDto);

            return Result<bool>.Success(message: "کاربر با موفقیت ثبت شد");
        }
    }
}
