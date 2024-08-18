using Volo.Abp.Domain.Repositories;

namespace Kun.BookStore.Books
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookRepository : IRepository<Book, Guid>
    {
    }
}
