using Kun.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
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
        context.Services.AddAbpDbContext<BookStoreDbContext>(options => { options.AddDefaultRepositories(includeAllEntities: true); });
        Configure<AbpDbContextOptions>(options => { options.UseSqlServer(); });
        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<Book>(entityOptions => { entityOptions.DefaultWithDetailsFunc = query => query.Include(book => book.Volumes).ThenInclude(volume => volume.Chapters); });
        });
    }
}
