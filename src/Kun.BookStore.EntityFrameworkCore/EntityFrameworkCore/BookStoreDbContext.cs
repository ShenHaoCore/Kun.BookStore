using Kun.BookStore.Authors;
using Kun.BookStore.Books;
using Kun.BookStore.Categories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kun.BookStore.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
[ConnectionStringName("BookStore")]
public class BookStoreDbContext : AbpDbContext<BookStoreDbContext>
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Volume> Volumes { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<ChapterText> ChapterTexts { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
