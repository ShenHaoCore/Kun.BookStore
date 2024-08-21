using Volo.Abp.Modularity;

namespace Kun.BookStore.SqlSugarCore;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(BookStoreDomainModule))]
public class BookStoreSqlSugarCoreModule : AbpModule
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
