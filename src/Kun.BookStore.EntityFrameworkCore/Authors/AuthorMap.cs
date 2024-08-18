using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class AuthorMap : IEntityTypeConfiguration<Author>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(nameof(Author));
        builder.ConfigureByConvention();
        builder.Property(author => author.Name).IsRequired().HasMaxLength(AuthorConsts.MaxNameLength);
        builder.Property(author => author.Description).HasMaxLength(AuthorConsts.MaxDescriptionLength);
    }
}
