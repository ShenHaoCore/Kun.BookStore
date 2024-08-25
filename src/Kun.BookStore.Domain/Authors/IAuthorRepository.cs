using Volo.Abp.Domain.Repositories;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public interface IAuthorRepository : IRepository<Author, Guid>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<Author?> FindByNameAsync(string name);
}
