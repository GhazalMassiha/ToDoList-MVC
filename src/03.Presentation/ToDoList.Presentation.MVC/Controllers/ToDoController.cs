using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.TaskAgg.DTOs;
using ToDoList.Domain.Core.ToDoItemAgg.Contracts.ServiceContracts;
using ToDoList.Presentation.MVC.Database;
using ToDoList.Presentation.MVC.Models;
using ToDoList.Framework;

namespace ToDoList.Presentation.MVC.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoItemApplicationService _todoAppSvc;
        private readonly ICategoryApplicationService _categoryAppSvc;

        public ToDoController(IToDoItemApplicationService todoAppSvc, ICategoryApplicationService categoryAppSvc)
        {
            _todoAppSvc = todoAppSvc;
            _categoryAppSvc = categoryAppSvc;
        }

        public IActionResult Index(string search, int? categoryId, string sort)
        {
            var online = InMemoryDatabase.OnlineUser;
            if (online == null)
                return RedirectToAction("Login", "User");

            var items = _todoAppSvc.GetUserItem(online.Id, search, categoryId, sort);

            var vmList = items.Select(t => new TodoItemViewModel
            {
                Id = t.Id,
                Title = t.Title,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted,
                CategoryName = _categoryAppSvc.GetAllCategories()
                                .FirstOrDefault(c => c.Id == t.CategoryId)?.Name ?? ""
            }).ToList();

            ViewBag.Categories = _categoryAppSvc.GetAllCategories();
            ViewBag.Search = search;
            ViewBag.CategoryId = categoryId;
            ViewBag.Sort = sort;

            return View(vmList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var online = InMemoryDatabase.OnlineUser;
            if (online == null) return RedirectToAction("Login", "User");

            ViewBag.Categories = _categoryAppSvc.GetAllCategories();
            return View(new TodoItemCreateViewModel());
        }

        [HttpPost]
        public IActionResult Add(TodoItemCreateViewModel vm)
        {
            var online = InMemoryDatabase.OnlineUser;
            if (online == null) return RedirectToAction("Login", "User");

            DateTime? due = vm.DueDateString.ParsePersianDate();
            if (due == null)
            {
                ModelState.AddModelError(nameof(vm.DueDateString), "تاریخ وارد شده معتبر نیست.");
                ViewBag.Categories = _categoryAppSvc.GetAllCategories();
                return View("Create", vm);
            }

            var dto = new ToDoItemCreateDto
            {
                Title = vm.Title,
                DueDate = due.Value,
                CategoryId = vm.CategoryId,
                UserId = online.Id
            };

            var result = _todoAppSvc.CreateItem(online.Id, dto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Toggle(int id)
        {
            var online = InMemoryDatabase.OnlineUser;
            if (online == null)
                return RedirectToAction("Login", "User");

            var editDto = new ToDoItemEditDto { IsCompleted = true }; 
            var res = _todoAppSvc.MarkItemComplete(id, editDto);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var online = InMemoryDatabase.OnlineUser;
            if (online == null)
                return RedirectToAction("Login", "User");

            var res = _todoAppSvc.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
