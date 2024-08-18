using Volo.Abp.Modularity;

namespace Kun.BookStore
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(typeof(BookStoreDomainSharedModule))]
    public class BookStoreDomainModule : AbpModule
    {
    }
}
