using Kun.BookStore.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Kun.BookStore.Categories;

/// <summary>
/// 
/// </summary>
public class CategoryMap : IEntityTypeConfiguration<Category>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));
        builder.ConfigureByConvention();
        builder.Property(category => category.Name).IsRequired();
    }
}
