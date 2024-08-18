using Volo.Abp.Domain.Repositories;

namespace Kun.BookStore.Authors;

public interface IAuthorRepository : IRepository<Author, Guid>
{

}
