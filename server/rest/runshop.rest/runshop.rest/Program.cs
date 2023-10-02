using FluentValidation;
using Microsoft.EntityFrameworkCore;
using runShop.data;
using runShop.data.unit;
using runShop.services.user;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using runShop.rest.AuthUtils;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("runShop.rest"));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAutoMapper(builder =>builder.AddMaps(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);



builder.Services.AddScoped<IUnit,DataUnit>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddSingleton<JwtUtils>(); 



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header. \r\n\r\n Enter the token in the text input below.",
    });
});




builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =  JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        IssuerSigningKey = new  SymmetricSecurityKey
        (Encoding.UTF8.GetBytes("dhisah8ydghsahduihas8iydghuyasbgduy1276w351243e512473e123eu0812y439712h8yebg8123eg712fge7 wnhdg786awdvbgusbacuhjvsuycbsianxuisabhc8iysagd78t7q6we23q7e51234e56idbs8uyadf76awfr")),
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuerSigningKey =  true
    };
});

builder.Services.AddAuthorization();


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
