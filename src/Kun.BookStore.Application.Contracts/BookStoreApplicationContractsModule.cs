using Volo.Abp.Modularity;

namespace Kun.BookStore.Application.Contracts;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(BookStoreDomainSharedModule))]
public class BookStoreApplicationContractsModule : AbpModule
{
}
