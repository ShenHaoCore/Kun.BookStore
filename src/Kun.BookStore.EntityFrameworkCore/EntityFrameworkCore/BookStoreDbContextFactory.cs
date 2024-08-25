using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kun.BookStore.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public BookStoreDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var builder = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(configuration.GetConnectionString("BookStore"));
        return new BookStoreDbContext(builder.Options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
        return builder.Build();
    }
}
