using Kun.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kun.BookStore.Books;

/// <summary>
/// 
/// </summary>
public class BookRepository : EfCoreRepository<BookStoreDbContext, Book, Guid>, IBookRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbContextProvider"></param>
    public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="include"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default)
    {
        var db = await GetDbContextAsync();
        var chapters = db.Chapters;
        var result = await chapters.IncludeIf(include, chapter => chapter.ChapterText).FirstOrDefaultAsync(chapter => chapter.Id == id, GetCancellationToken(cancellationToken));
        return result;
    }
}
