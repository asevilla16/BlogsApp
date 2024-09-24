using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlogsApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BlogsAppDbContextFactory : IDesignTimeDbContextFactory<BlogsAppDbContext>
{
    public BlogsAppDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        BlogsAppEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<BlogsAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new BlogsAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BlogsApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
