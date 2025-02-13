using EcommerceAPI.Persistance;
using EcommerceAPI.Application;
using EcommerceAPI.Infrastructure;
using EcommerceAPI.Mapper;
using EcommerceAPI.Application.Exceptions;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using Serilog;
using EcommerceAPI.Infrastructure.Logging;
namespace EcommerceAPI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Cross-Origin Resource Sharing
            //AllowAll - Dangerous 
            var corsPolicy = "AllowAll";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicy,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });


            // Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("C:\\Users\\Arif\\Desktop\\EcommerceAPI\\Logs\\log.txt",
                rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog();



            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddLoggingServices(builder.Configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            var env = builder.Environment;
            builder.Configuration
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddCustomMapper();


            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcommerceAPI", Version = "v1" });

                // JWT Auth 
                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "JWT Tokeni bu formatda daxil edin: Bearer [token]"
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
                                 new string[] {}
                          }
                });
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSerilogRequestLogging();
            app.ConfigureExceptionHandlingMiddleware();
            app.UseCors(corsPolicy);
            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
