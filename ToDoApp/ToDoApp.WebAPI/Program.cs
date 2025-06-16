using System.Security.Cryptography.Xml;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ToDoApp.Bussines;
using ToDoApp.Bussiness;
using ToDoApp.Bussiness.Helpers;
using ToDoApp.DataAccess;
using ToDoApp.Entities.Configurations;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))

            };
        });
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));


        builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
        builder.Services.AddScoped<IToDoUserRepository, ToDoUserRepository>();
        builder.Services.AddScoped<IToDoTaskService, ToDoTaskManager>();
        builder.Services.AddScoped<IToDoUserService, ToDoUserManager>();
        builder.Services.AddScoped<IGoogleCalendarService, GoogleCalendarManager>();
        builder.Services.AddScoped<TokenHelper>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
            });

            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                        TokenUrl = new Uri("https://oauth2.googleapis.com/token"),
                        Scopes = new Dictionary<string, string>
                        {
                     { "https://www.googleapis.com/auth/calendar", "Access to Google Calendar" },
                    { "https://www.googleapis.com/auth/userinfo.email", "Access your email" },
                    { "openid", "OpenID Connect scope" }
                        }
                    }
                }
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
       {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new List<string>()
       }
    });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "oauth2",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new[] { "https://www.googleapis.com/auth/calendar", "https://www.googleapis.com/auth/userinfo.email" }
        }
    });

        });
        builder.Services.AddCors(policy =>
        {
            policy.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
            });
        });


        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API V1");
                c.OAuthClientId("YOUR_OAUTH_CLIENT_ID");
                c.OAuthClientSecret("YOUR_OAUTH_CLIENT_SECRET");
                c.OAuthAppName("ToDo API Swagger UI");
                c.OAuth2RedirectUrl("http://localhost:5144/swagger/oauth2-redirect.html");
                c.OAuthUsePkce();

            });
        }
        app.UseCors("AllowAll");
        //app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}