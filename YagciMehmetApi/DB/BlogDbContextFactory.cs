using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YagciMehmetApi.DB
{
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        BlogDbContext IDesignTimeDbContextFactory<BlogDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BlogDbContext>();
            var connectionString = configuration.GetConnectionString("YagciMehmetConnection");
            builder.UseSqlite(connectionString);
            return new BlogDbContext(builder.Options);
        }
    }
}