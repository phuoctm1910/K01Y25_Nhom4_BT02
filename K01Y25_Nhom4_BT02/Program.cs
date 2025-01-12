using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using K01Y25_Nhom4_BT02.DB;
using DotNetEnv;

namespace K01Y25_Nhom4_BT02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load .env file
            Env.Load();

            // Bind environment variables directly to IConfiguration
            builder.Configuration.AddEnvironmentVariables();

            // Build connection string from environment variables
            string connectionString = $"Host={builder.Configuration["DATABASE_HOST"]};" +
                                      $"Port={builder.Configuration["DATABASE_PORT"]};" +
                                      $"Username={builder.Configuration["DATABASE_USER"]};" +
                                      $"Password={builder.Configuration["DATABASE_PASSWORD"]};" +
                                      $"Database={builder.Configuration["DATABASE_NAME"]}";

            // Add connection string to IConfiguration
            builder.Configuration["ConnectionStrings:DbConnection"] = connectionString;

            // Use Autofac as Service Provider
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                // Register AppDbContext with Autofac
                containerBuilder.RegisterType<AppDbContext>()
                                .AsSelf()
                                .WithParameter("options", new DbContextOptionsBuilder<AppDbContext>()
                                    .UseNpgsql(connectionString)
                                    .Options)
                                .InstancePerLifetimeScope();

                // Automatically register all services ending with "Service"
                containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Service"))
                                .AsImplementedInterfaces()
                                .InstancePerLifetimeScope();
            });

            // Register services with built-in DI
            builder.Services.AddControllers()
               .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.DateFormatString = "dd-MM-yyyy";
               });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register EF Core with Npgsql
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(connectionString);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
