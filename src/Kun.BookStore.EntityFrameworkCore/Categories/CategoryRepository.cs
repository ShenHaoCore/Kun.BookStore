using Kun.BookStore.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kun.BookStore.Categories;

/// <summary>
/// 
/// </summary>
public class CategoryRepository : EfCoreRepository<BookStoreDbContext, Category, Guid>, ICategoryRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbContextProvider"></param>
    public CategoryRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
