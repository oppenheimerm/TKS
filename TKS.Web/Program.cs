using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TKS.Core.Helpers.Imaging;
using TKS.Datastore.EFCore;
using TKS.UseCases;
using TKS.UseCases.CategoryUseCase;
using TKS.UseCases.Folder;
using TKS.UseCases.ProductsUseCase;
using TKS.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


//  Add the Authentication Middleware services with the AddAuthentication and AddCookie methods.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

//  Admin folder to prevent unauthorised users being able to access anything in it.
builder.Services.AddMvc().AddRazorPagesOptions(options => {
    options.Conventions.AuthorizeFolder("/admin");
});

builder.Services.AddSingleton<ImageProcessor>();
builder.Services.AddSingleton<IUserService, UserServices>();

//  Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFolderDbEntityRepository, FolderDbEntityRepository>();
builder.Services.AddScoped<IPhotoDbEntityRepository, PhotoDbEntityRepository>();

//  Usercases
builder.Services.AddTransient<IAddProductUseCase, AddProduct>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategory>();
builder.Services.AddTransient<IGetAllCategories, GetAllCategories>();
builder.Services.AddTransient<ICategoryCodeUniqueUseCase, CategoryCodeUniqueUseCase>();
builder.Services.AddTransient<IAddProductPhotoUseCase, AddProductPhotoUseCase>();
builder.Services.AddTransient<IAddFolderUseCase, AddFolderUseCase>();
builder.Services.AddTransient<IAddFolderDbEntityUseCase, AddFolderDbEntityUseCase>();
builder.Services.AddTransient<IAddPhotoDbEntityUseCase, AddPhotoDbEntityUseCase>();
builder.Services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
builder.Services.AddTransient<IGetAllProductUseCase, GetAllProductUseCase>();
builder.Services.AddTransient<IGetCategory, GetCategory>();
builder.Services.AddTransient<IEditCategory, EditCategory>();
builder.Services.AddTransient<IGetProductUseCase, GetProduct>();
builder.Services.AddTransient<IViewByCategory, ViewByCategory>();


builder.Services.AddScoped<IPhotoFileRepository, PhotoFileRepository>();
builder.Services.AddScoped<IFolderFileRepository, FolderFileRepository>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//  Call UseAuthentication
//  UseAuthorization to set the HttpContext.User property and run the Authorization
//  Middleware for requests.  UseAuthentication and UseAuthorization must be called
//  before Map methods such as MapRazorPages and MapDefaultControllerRoute
app.UseAuthentication();


app.MapDefaultControllerRoute();


app.UseHttpsRedirection();
app.UseStaticFiles();

//  make use of a pages that you create to generate error response,
//  i.e 404, 500...
app.UseStatusCodePagesWithRedirects("/errors/{0}");

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
