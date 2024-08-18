using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Kun.BookStore.Books;

/// <summary>
/// 
/// </summary>
public class ChapterTextMap : IEntityTypeConfiguration<ChapterText>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<ChapterText> builder)
    {
        builder.ToTable(nameof(ChapterText));
        builder.ConfigureByConvention();
        builder.Property(chapterText => chapterText.Content);
    }
}
