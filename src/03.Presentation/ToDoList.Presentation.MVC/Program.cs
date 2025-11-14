using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.EFCore.Persistence;
using ToDoList.Infrastructure.EFCore.Repositories;
using ToDoList.Service;
using ToDoList.ApplicationService;
using ToDoList.Domain.Core.UserAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.UserAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.CategoryAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.TaskAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.ToDoItemAgg.Contracts.ServiceContracts;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();


builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();
builder.Services.AddScoped<ICategoryApplicationService, CategoryApplicationService>();
builder.Services.AddScoped<IToDoItemApplicationService, ToDoItemApplicationService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
