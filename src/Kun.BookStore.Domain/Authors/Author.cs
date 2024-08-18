using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kun.BookStore.Authors;

/// <summary>
/// 作者
/// </summary>
public class Author : FullAuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 作者
    /// </summary>
    private Author()
    {
    }

    /// <summary>
    /// 作者
    /// </summary>
    /// <param name="id">ID</param>
    /// <param name="name">名称</param>
    /// <param name="description">描述</param>
    public Author(Guid id, [NotNull] string name,string description) : base(id)
    {
        SetName(name);
        Description = description;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    internal Author ChangeName([NotNull] string name)
    {
        SetName(name);
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: AuthorConsts.MaxNameLength);
    }
}
