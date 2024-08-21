using System.ComponentModel.DataAnnotations;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class UpdateAuthorDto
{
    [Required]
    [StringLength(AuthorConsts.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string Description { get; set; } = string.Empty;
}
