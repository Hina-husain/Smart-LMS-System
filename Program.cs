using Microsoft.AspNetCore.Authentication.Cookies;
using MongoDB.Driver;
using SmartLMS.Interfaces;
using SmartLMS.Repositories;
using SmartLMS.Services;
using SmartLMS.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// MongoDB Setup
var mongoConnectionString = builder.Configuration.GetSection("MongoDBSettings:ConnectionString").Value;
var mongoDatabaseName = builder.Configuration.GetSection("MongoDBSettings:DatabaseName").Value;

if (!string.IsNullOrEmpty(mongoConnectionString))
{
    var mongoClient = new MongoClient(mongoConnectionString);
    builder.Services.AddSingleton<IMongoDatabase>(mongoClient.GetDatabase(mongoDatabaseName));
}

// CONCEPT: Dependency Injection Container Registration
// Register generic repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(MongoRepository<>));
// Register business logic services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IQuizService, QuizService>();

// Authentication Setup
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(12);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// CONCEPT: Custom Middleware for Error Handling
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
