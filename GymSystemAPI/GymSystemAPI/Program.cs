using GymSystemAPI.Models.Domain;
using GymSystemAPI.Services;
using GymSystemAPI.Services.Login;
using GymSystemAPI.Services.QRCode;
using GymSystemAPI.Services.Registeration;
using GymSystemAPI.Services.Settings;
using GymSystemAPI.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Login
services.AddTransient<ILoginService, ManagerLogin>();
services.AddTransient<ILoginService,TrainerLogin>();
services.AddTransient<ILoginService,TraineeLogin>();

//Token
services.AddTransient<ITokenService, Token>();

//Register

services.AddTransient<IRegistrationService, TraineeRegisteration>();

services.AddTransient<ISettingsService, UserSettings>();

services.AddTransient<IQRCodeService,QrCode >();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
           builder => builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                             .AllowAnyMethod());
});

//services.AddIdentity<User, IdentityRole>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "please enter token",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    }
    );
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("gymsystem")!;
    options.UseSqlServer(connectionString);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
