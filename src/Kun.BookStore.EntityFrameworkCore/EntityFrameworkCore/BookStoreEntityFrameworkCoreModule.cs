using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace Kun.BookStore.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreSqlServerModule))]
[DependsOn(typeof(BookStoreDomainModule))]
public class BookStoreEntityFrameworkCoreModule : AbpModule
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BookStoreDbContext>(options => { options.AddDefaultRepositories(); });
        Configure<AbpDbContextOptions>(options => { options.UseSqlServer(); });
    }
}
