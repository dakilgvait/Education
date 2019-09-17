using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Person.DAL.Context
{
    public abstract class ConfigContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();

                options.UseSqlServer(ConfigurationExtensions.GetConnectionString(config, "EntityContext"));
            }
            base.OnConfiguring(options);
        }
    }
}