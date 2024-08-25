using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kun.BookStore.Books;

/// <summary>
/// 章节
/// </summary>
public class Chapter : FullAuditedEntity<Guid>
{
    /// <summary>
    /// 分卷
    /// </summary>
    public Volume Volume { get; set; }

    /// <summary>
    /// 分卷ID
    /// </summary>
    public Guid VolumeId { get; set; } 

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 章节内容
    /// </summary>
    public ChapterText ChapterText { get; protected set; }

    /// <summary>
    /// 标题
    /// </summary>
    public int WordsNumber { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// 章节
    /// </summary>
    private Chapter()
    {
        
    }

    /// <summary>
    /// 章节
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    /// <param name="authorMessage">作者留言</param>
    public Chapter(string title, string content, string? authorMessage = null)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        ChapterText = new ChapterText(content, authorMessage);
        WordsNumber = content.Length;
    }
}
