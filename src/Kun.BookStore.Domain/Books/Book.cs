using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kun.BookStore.Books;

/// <summary>
/// 书
/// </summary>
public class Book : AuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTime PublishDate { get; set; }

    /// <summary>
    /// 作者
    /// </summary>
    public Guid AuthorId { get; set; }

    /// <summary>
    /// 作者名称
    /// </summary>
    public string AuthorName { get; set; }

    /// <summary>
    /// 类别
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// 类别名称
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Volume> Volumes { get; protected set; }

    /// <summary>
    /// 书
    /// </summary>
    private Book()
    {

    }

    /// <summary>
    /// 书
    /// </summary>
    /// <param name="id">ID</param>
    /// <param name="name">名称</param>
    /// <param name="publishDate">发布日期</param>
    /// <param name="authorId">作者ID</param>
    /// <param name="authorName">作者名称</param>
    /// <param name="categoryId">类别ID</param>
    /// <param name="categoryName">类别名称</param>
    public Book(Guid id, [NotNull] string name, DateTime publishDate, Guid authorId, string authorName, Guid categoryId, string categoryName) : base(id)
    {
        SetName(name);
        PublishDate = publishDate;
        AuthorId = authorId;
        AuthorName = Check.NotNullOrWhiteSpace(authorName, nameof(authorName));
        CategoryId = categoryId;
        CategoryName = Check.NotNullOrWhiteSpace(categoryName, nameof(categoryName));
        Volumes = new List<Volume>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">名称</param>
    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: BookConsts.MaxNameLength);
    }

    /// <summary>
    /// 添加分卷
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="description">描述</param>
    public void AddVolume(string title, string description = null)
    {
        if (Volumes.Any(volume => volume.Title == title)) { return; }
        Volumes.Add(new Volume(title, description));
    }

    /// <summary>
    /// 移除分卷
    /// </summary>
    /// <param name="volumeId">分卷ID</param>
    public void RenoveVolume(Guid volumeId)
    {
        Volumes.RemoveAll(volume => volume.Id == volumeId);
    }
}
