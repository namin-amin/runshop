using FluentValidation;
using Microsoft.EntityFrameworkCore;
using runShop.data;
using runShop.data.unit;
using runShop.services.user;
using runShop.services.auth;
using runShop.rest.AuthUtils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

var KEY = builder.Configuration.GetValue<string>("Authentication:Schemes:Bearer:Key");

if (KEY is null)
    throw new ArgumentNullException(nameof(KEY));


// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly(assemblyName: "runShop.rest"));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAutoMapper(builder =>builder.AddMaps(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

//Application 
builder.Services.AddScoped<IUnit,DataUnit>();
builder.Services.AddScoped<IUserService,UserService>();



//Auth Related Services
builder.Services.AddJwtUtil(KEY);
builder.Services.AddSingleton<IPassWordHash>(new BcryptPasswordHash(KEY));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddBearer(KEY.ToString());
var multiSchemePolicy = new AuthorizationPolicyBuilder(
    CookieAuthenticationDefaults.AuthenticationScheme,
    JwtBearerDefaults.AuthenticationScheme)
  .RequireAuthenticatedUser()
  .Build();

builder.Services.AddAuthorization(o=>o.DefaultPolicy = multiSchemePolicy);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();
