using Kun.BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Kun.BookStore.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
public class EntityFrameworkCoreBookStoreDbSchemaMigrator : IBookStoreDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceProvider"></param>
    public EntityFrameworkCoreBookStoreDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task MigrateAsync()
    {
        await _serviceProvider.GetRequiredService<BookStoreDbContext>().Database.MigrateAsync();
    }
}
