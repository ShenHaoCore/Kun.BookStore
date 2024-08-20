using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Kun.BookStore.Books;

/// <summary>
/// 分卷
/// </summary>
public class Volume : Entity<Guid>, IHasCreationTime
{
    /// <summary>
    /// 
    /// </summary>
    public Book? Book { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid BookId { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Chapter> Chapters { get; protected set; } = new List<Chapter>();

    /// <summary>
    /// 
    /// </summary>
    public DateTime CreationTime { get; }

    /// <summary>
    /// 分卷
    /// </summary>
    private Volume()
    {

    }

    /// <summary>
    /// 分卷
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="description">描述</param>
    public Volume(string title, string? description = null)
    {
        Title = title;
        Description = description;
    }

    /// <summary>
    /// 添加章节
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    public void CreateChapter(string title, string content)
    {
        if (Chapters.Any(chapter => chapter.Title == title)) { return; }
        Chapters.Add(new Chapter(title, content));
    }

    /// <summary>
    /// 移除章节
    /// </summary>
    /// <param name="chapterId">章节ID</param>
    public void RemoveChapter(Guid chapterId)
    {
        Chapters.RemoveAll(chapter => chapter.Id == chapterId);
    }
}
