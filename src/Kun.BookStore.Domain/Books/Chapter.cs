using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Kun.BookStore.Books;

/// <summary>
/// 章
/// </summary>
public class Chapter : Entity<Guid>, IHasCreationTime
{
    /// <summary>
    /// 
    /// </summary>
    public Volume Volume { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid VolumeId { get; set; } 

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ChapterText ChapterText { get; protected set; }

    /// <summary>
    /// 标题
    /// </summary>
    public int WordsNumber { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreationTime { get; }

    /// <summary>
    /// 章
    /// </summary>
    private Chapter()
    {
        
    }

    /// <summary>
    /// 章
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    /// <param name="authorMessage">作者留言</param>
    public Chapter(string title, string content, string authorMessage = null)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        ChapterText = new ChapterText(content, authorMessage);
        WordsNumber = content.Length;
    }
}
