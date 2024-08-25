namespace Kun.BookStore.Data;

/// <summary>
/// 
/// </summary>
public interface IBookStoreDbSchemaMigrator
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task MigrateAsync();
}
