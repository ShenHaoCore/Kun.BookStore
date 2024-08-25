using Volo.Abp;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class AuthorAlreadyExistsException : BusinessException
{
    /// <summary>
    /// 
    /// </summary>
    public AuthorAlreadyExistsException(string name) : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
    {
        WithData("name", name);
    }
}
