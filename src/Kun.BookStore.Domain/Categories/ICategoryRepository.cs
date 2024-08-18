using Volo.Abp.Domain.Repositories;

namespace Kun.BookStore.Categories;

/// <summary>
/// 
/// </summary>
public interface ICategoryRepository : IRepository<Category, Guid>
{
}
