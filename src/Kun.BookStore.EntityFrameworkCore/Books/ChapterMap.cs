using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Kun.BookStore.Books;

/// <summary>
/// 
/// </summary>
public class ChapterMap : IEntityTypeConfiguration<Chapter>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.ToTable(nameof(Chapter));
        builder.ConfigureByConvention();
        builder.Property(chapter => chapter.Title);
        //builder.HasOne<Volume>(chapter => chapter.Volume).WithMany(volume => volume.Chapters).IsRequired().HasForeignKey(x => x.VolumeId);
    }
}
