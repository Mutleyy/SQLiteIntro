using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLiteIntro.DAL;
using StructureMap;
using System;
using System.IO;

namespace SQLiteIntro
{
    public static class ServiceProvider
    {
        public static IServiceProvider Instance { get; }

        static ServiceProvider() => Instance = ConfigureServices();

        private static IServiceProvider ConfigureServices()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");  

            var serviceCollection = new ServiceCollection()
                .AddEntityFrameworkSqlite()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

            var container = new Container();
            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                });
                config.Populate(serviceCollection);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
