using Volo.Abp.Application.Dtos;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class AuthorDto : EntityDto<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; } = string.Empty;
}
