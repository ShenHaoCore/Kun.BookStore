using Kun.BookStore.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Kun.BookStore.Books;

/// <summary>
/// 
/// </summary>
public class BookMap : IEntityTypeConfiguration<Book>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(nameof(Book));
        builder.ConfigureByConvention();
        builder.Property(book => book.Name).IsRequired().HasMaxLength(BookConsts.MaxNameLength);
        //builder.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
    }
}
