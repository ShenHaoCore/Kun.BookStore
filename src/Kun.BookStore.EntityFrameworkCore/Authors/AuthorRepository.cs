using Kun.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class AuthorRepository : EfCoreRepository<BookStoreDbContext, Author, Guid>, IAuthorRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbContextProvider"></param>
    public AuthorRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<Author?> FindByNameAsync(string name)
    {
        var db = await GetDbSetAsync();
        return await db.FirstOrDefaultAsync(author => author.Name == name);
    }
}
