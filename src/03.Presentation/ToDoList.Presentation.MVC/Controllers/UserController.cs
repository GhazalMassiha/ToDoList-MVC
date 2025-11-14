using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Core.UserAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.UserAgg.DTOs;
using ToDoList.Presentation.MVC.Models;
using ToDoList.Presentation.MVC.Database;

namespace ToDoList.Presentation.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApplicationService _userAppSvc;

        public UserController(IUserApplicationService userAppSvc)
        {
            _userAppSvc = userAppSvc;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new UserCreateDto
            {
                Username = vm.Username,
                Password = vm.Password
            };

            var result = _userAppSvc.Register(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(vm);
            }

           
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var result = _userAppSvc.Login(vm.Username, vm.Password);
            if (!result.IsSuccess || result.Data == null)
            {
                ModelState.AddModelError("", result.Message);
                return View(vm);
            }


            InMemoryDatabase.OnlineUser = new OnlineUser
            {
                Id = result.Data.Id,
                Username = result.Data.Username
            };

            return RedirectToAction("Index", "Todo");
        }

        public IActionResult Logout()
        {
            InMemoryDatabase.OnlineUser = null;
            return RedirectToAction(nameof(Login));
        }
    }
}
