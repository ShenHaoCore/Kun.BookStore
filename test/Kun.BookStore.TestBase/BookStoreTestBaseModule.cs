using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Kun.BookStore;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpTestBaseModule))]
[DependsOn(typeof(BookStoreDomainModule))]
public class BookStoreTestBaseModule : AbpModule
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        AsyncHelper.RunSync(async () =>
        {
            using (IServiceScope scope = context.ServiceProvider.CreateScope())
            {
                await scope.ServiceProvider.GetRequiredService<IDataSeeder>().SeedAsync();
            }
        });
    }
}
