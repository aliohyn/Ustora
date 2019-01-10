using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ustora.Data
{
    public class UstoraContextFactory : IDesignTimeDbContextFactory<UstoraContext>
    {
        public UstoraContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<UstoraContext>();

            var connectionString = configuration.GetConnectionString("UstoraConnection");

            builder.UseSqlServer(connectionString);

            return new UstoraContext(builder.Options);
        }
    }
}