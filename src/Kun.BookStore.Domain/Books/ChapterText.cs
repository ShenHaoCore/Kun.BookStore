using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kun.BookStore.Books;

/// <summary>
/// 章节文本
/// </summary>
public class ChapterText : AuditedEntity<Guid>
{
    /// <summary>
    /// 
    /// </summary>
    public Chapter Chapter { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid ChapterId { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 作者留言
    /// </summary>
    public string? AuthorMessage { get; set; }

    /// <summary>
    /// 章节文本
    /// </summary>
    private ChapterText()
    {

    }

    /// <summary>
    /// 章节文本
    /// </summary>
    /// <param name="content">内容</param>
    /// <param name="authorMessage">作者留言</param>
    public ChapterText(string content, string authorMessage = null)
    {
        Content = Check.NotNullOrWhiteSpace(content, nameof(content));
        AuthorMessage = authorMessage;
    }
}
