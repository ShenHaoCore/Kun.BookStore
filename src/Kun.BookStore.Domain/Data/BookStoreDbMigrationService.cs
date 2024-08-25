using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Kun.BookStore.Data;

/// <summary>
/// 
/// </summary>
public class BookStoreDbMigrationService : ITransientDependency
{
    private readonly IDataSeeder _dataSeeder;
    private readonly IEnumerable<IBookStoreDbSchemaMigrator> _dbSchemaMigrators;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataSeeder"></param>
    /// <param name="dbSchemaMigrators"></param>
    public BookStoreDbMigrationService(IDataSeeder dataSeeder, IEnumerable<IBookStoreDbSchemaMigrator> dbSchemaMigrators)
    {
        _dataSeeder = dataSeeder;
        _dbSchemaMigrators = dbSchemaMigrators;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task MigrateAsync()
    {
        foreach (var migrator in _dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
        await _dataSeeder.SeedAsync();
    }
}
