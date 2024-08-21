using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Kun.BookStore;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(AbpAutoMapperModule))]
[DependsOn(typeof(BookStoreDomainModule))]
public class BookStoreApplicationModule : AbpModule
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<BookStoreApplicationModule>(true); });
    }
}
