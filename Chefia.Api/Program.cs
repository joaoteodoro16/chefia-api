using Chefia.Api.Http;
using Chefia.Domain.Repositories;
using Chefia.App.Usecases.Company;
using Chefia.App.Usecases.Company.Create;
using Chefia.Infra.Context;
using Chefia.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Chefia.App.Usecases.Company.GetAll;
using Chefia.Domain.Services.Security;
using Chefia.Infra.Services.Security;
using Chefia.Api.Settings;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Chefia.App.Usecases.User.Create;
using Chefia.App.Usecases.User.Auth;
using Chefia.App.Usecases.User.Update;
using Chefia.Infra.Services.Session;
using Chefia.App.Services;
using Chefia.App.Usecases.Product.Create;
using Chefia.App.Usecases.ProductCategory.Create;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// Services
builder.Services.AddScoped<IPasswordHasher, ByCryptService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// Company
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICreateCompanyUsecase, CreateCompanyUsecase>();
builder.Services.AddScoped<IGetCompaniesUsecase, GetCompaniesUsecase>();

// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUserUsecase, CreateUserUsecase>();
builder.Services.AddScoped<IUserAuthUsecase, UserAuthUsecase>();
builder.Services.AddScoped<IUpdateUserUsecase, UpdateUserUsecase>();

//Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICreateProductUsecase, CreateProductUsecase>();

//Product Category
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<ICreateProductCategoryUsecase, CreateProductCategoryUsecase>();

// JWT Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt")); // ← linha adicionada

var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>()!;
var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddOpenApi();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().AllowAnonymous();
    app.MapScalarApiReference().AllowAnonymous();
}

app.Run();