using Kun.BookStore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Kun.BookStore.DbMigrator;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(BookStoreEntityFrameworkCoreModule))]
public class BookStoreDbMigratorModule : AbpModule
{
}
