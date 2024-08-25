using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class AuthorManager : DomainService
{
    private readonly IAuthorRepository _authorRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="authorRepository"></param>
    public AuthorManager(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="author"></param>
    /// <param name="newName"></param>
    /// <returns></returns>
    /// <exception cref="AuthorAlreadyExistsException"></exception>
    public async Task ChangeNameAsync([NotNull] Author author, [NotNull] string newName)
    {
        Check.NotNull(author, nameof(author));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingAuthor = await _authorRepository.FindByNameAsync(newName);
        if (existingAuthor != null && existingAuthor.Id != author.Id) { throw new AuthorAlreadyExistsException(newName); }
        author.ChangeName(newName);
    }
}
