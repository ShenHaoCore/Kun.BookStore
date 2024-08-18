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
    /// <summary>
    /// 
    /// </summary>
    public DbSet<Author> Authors { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Volume> Volumes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Chapter> Chapters { get; set; }

    /// <summary>
    /// 
    /// </summary>
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
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
