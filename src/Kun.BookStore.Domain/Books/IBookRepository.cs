using Volo.Abp.Domain.Repositories;

namespace Kun.BookStore.Books;

/// <summary>
/// 
/// </summary>
public interface IBookRepository : IRepository<Book, Guid>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="include"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Chapter?> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default);
}
