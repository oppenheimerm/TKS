using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TKS.Web.Data;
using TKS.Web.Helpers.Imaging;
using TKS.Web.Repositories;
using TKS.Web.UseCases;
using TKS.Web.UseCases.CategoryUseCase;
using TKS.Web.UseCases.Folder;
using TKS.Web.UseCases.ProductsUseCase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSingleton<ImageProcessor>();

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


builder.Services.AddScoped<IPhotoFileRepository, PhotoFileRepository>();
builder.Services.AddScoped<IFolderFileRepository, FolderFileRepository>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});


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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
