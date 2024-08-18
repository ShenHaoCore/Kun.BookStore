using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Kun.BookStore.Books;

/// <summary>
/// 
/// </summary>
public class VolumeMap : IEntityTypeConfiguration<Volume>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Volume> builder)
    {
        builder.ToTable(nameof(Volume));
        builder.ConfigureByConvention();
        builder.Property(volume => volume.Title).IsRequired().HasMaxLength(BookConsts.MaxNameLength);
    }
}
