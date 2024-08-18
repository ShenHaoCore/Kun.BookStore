using Kun.BookStore.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Kun.BookStore;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpTestBaseModule))]
public class BookStoreTestBaseModule : AbpModule
{
}
