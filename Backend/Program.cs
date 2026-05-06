using System.Text;
using Backend.Component.Application.Internal.CommandServices;
using Backend.Component.Application.Internal.QueryServices;
using Backend.Component.Domain.Repositories;
using Backend.Component.Domain.Services;
using Backend.Component.Infrastructure.Persistence.EFC.Repositories;
using Backend.IAM.Application.ACL.Services;
using Backend.IAM.Application.Internal.CommandServices;
using Backend.IAM.Application.Internal.OutboundServices;
using Backend.IAM.Application.Internal.QueryServices;
using Backend.IAM.Domain.Repositories;
using Backend.IAM.Domain.Services;
using Backend.IAM.Infrastructure.Hashing.BCrypt.Services;
using Backend.IAM.Infrastructure.Persistence.EFC.Repositories;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using Backend.IAM.Infrastructure.Tokens.JWT.Services;
using Backend.IAM.Interfaces.ACL;
using Backend.Interaction.Application.Internal.CommandServices;
using Backend.Interaction.Application.Internal.QueryServices;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Interfaces.ASAP.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend.Shared.Infrastructure.Pipeline.Middleware;
using Backend.TechnicalSupport.Application.Internal.CommandServices;
using Backend.TechnicalSupport.Application.Internal.QueryServices;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;
using Backend.TechnicalSupport.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
// Cart
using Backend.Orders.Application.Internal.CommandServices;
using Backend.Orders.Application.Internal.QueryServices;
using Backend.Orders.Domain.Repositories;
using Backend.Orders.Domain.Services;
using Backend.Orders.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

// Load environment variables from .env file
DotNetEnv.Env.Load();

// Create a builder for the application
var builder = WebApplication.CreateBuilder(args);

// Inject environment variables into the configuration system
builder.Configuration.AddEnvironmentVariables();

// Build the connection string from individual environment variables
var dbServer   = Environment.GetEnvironmentVariable("DB_SERVER")   ?? throw new Exception("DB_SERVER environment variable is not set");
var dbName     = Environment.GetEnvironmentVariable("DB_NAME")     ?? throw new Exception("DB_NAME environment variable is not set");
var dbUser     = Environment.GetEnvironmentVariable("DB_USER")     ?? throw new Exception("DB_USER environment variable is not set");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new Exception("DB_PASSWORD environment variable is not set");

var connectionString = $"Server={dbServer};Database={dbName};User={dbUser};Password={dbPassword};";

// Add services to the container.
// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();

// Configure Swagger/OpenAPI
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "PC Master Platform API",
            Version = "v1.2",
            Description = "PC Master",
            TermsOfService = new Uri("https://tp-pcmaster.web.app/home"),
            Contact = new OpenApiContact
            {
                Name  = "PCMaster",
                Email = "contact@pcmaster.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url  = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In          = ParameterLocation.Header,
            Description = "Please enter token",
            Name        = "Authorization",
            Type        = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme      = "bearer"
        });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id   = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            []
        }
    });
    options.EnableAnnotations();
});

// Configure DbContext with the connection string built from environment variables
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
    }
});

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy =>
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Technical Support BC
builder.Services.AddScoped<ITechnicalSupportRepository, TechnicalSupportRepository>();
builder.Services.AddScoped<ITechnicalSupportQueryService, TechnicalSupportQueryService>();
builder.Services.AddScoped<ITechnicalSupportCommandService, TechnicalSupportCommandService>();
builder.Services.AddScoped<ITechnicianRepository, TechnicianRepository>();
builder.Services.AddScoped<ITechnicianQueryService, TechnicianQueryService>();
builder.Services.AddScoped<ITechnicianCommandService, TechnicianCommandService>();

// Interaction BC
builder.Services.AddScoped<IComponentReviewRepository, ComponentReviewRepository>();
builder.Services.AddScoped<IComponentReviewQueryService, ComponentReviewQueryService>();
builder.Services.AddScoped<IComponentReviewCommandService, ComponentReviewCommandService>();

builder.Services.AddScoped<ITechnicalSupportReviewRepository, TechnicalSupportReviewRepository>();
builder.Services.AddScoped<ITechnicalSupportReviewQueryService, TechnicalSupportReviewQueryService>();
builder.Services.AddScoped<ITechnicalSupportReviewCommandService, TechnicalSupportReviewCommandService>();

builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
builder.Services.AddScoped<IWishlistQueryService, WishlistQueryService>();
builder.Services.AddScoped<IWishlistCommandService, WishlistCommandService>();

// Component BC
builder.Services.AddScoped<IComponentRepository, ComponentRepository>();
builder.Services.AddScoped<IComponentQueryService, ComponentQueryService>();
builder.Services.AddScoped<IComponentCommandService, ComponentCommandService>();

// Orders / Cart BC
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartQueryService, CartQueryService>();
builder.Services.AddScoped<ICartCommandService, CartCommandService>();

// IAM BC
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// Configure JWT Authentication
// TokenSettings__Secret, TokenSettings__Issuer and TokenSettings__Audience
// are loaded automatically from the .env file via AddEnvironmentVariables()
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = builder.Configuration["TokenSettings:Issuer"],
            ValidAudience            = builder.Configuration["TokenSettings:Audience"],
            IssuerSigningKey         = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["TokenSettings:Secret"] ?? string.Empty))
        };
    });

var app = builder.Build();

// Ensure database schema is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context  = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline
app.UseExceptionHandling();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllPolicy");

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();