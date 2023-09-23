using Business_Layer.Services.AccountService;
using Business_Layer.Services.CarService;
using Business_Layer.Services.RentalService;
using Data_Access_Layer.Contexts;
using Data_Access_Layer.Repositories.AccountRepository;
using Data_Access_Layer.Repositories.CarRepository;
using Data_Access_Layer.Repositories.RentalRepository;
using Data_Access_Layer.UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=.;Database=CarRental Store;MultipleActiveResultSets=True;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICarInventoryRepository, CarInventoryRepository>();
builder.Services.AddScoped<ICarInventoryService, CarInventoryService>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{

});

builder.Services.AddCors((option) =>
{
    option.AddDefaultPolicy((builder) => builder.WithOrigins("http://localhost:4200").AllowCredentials().AllowAnyMethod().AllowAnyHeader());
});




var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
