using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kun.BookStore.Categories;

/// <summary>
/// 类别
/// </summary>
public class Category : FullAuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 类别
    /// </summary>
    private Category()
    {
    }

    /// <summary>
    /// 类别
    /// </summary>
    /// <param name="id">ID</param>
    /// <param name="name">名称</param>
    public Category(Guid id, string name) : base(id)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
    }
}
