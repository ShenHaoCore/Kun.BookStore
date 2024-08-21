using Kun.BookStore.Authors;
using Kun.BookStore.Categories;
using Kun.BookStore.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Kun.BookStore.Books;

/// <summary>
/// 
/// </summary>
public sealed class BookRepositoryTests : BookStoreEntityFrameworkCoreTestBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IGuidGenerator _guidGenerator;

    /// <summary>
    /// 
    /// </summary>
    public BookRepositoryTests()
    {
        _bookRepository = GetRequiredService<IBookRepository>();
        _guidGenerator = GetRequiredService<IGuidGenerator>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Insert_A_Valid_Book()
    {
        Author author = new Author(_guidGenerator.Create(), "南派三叔", "网络文学20年十大悬疑作家");
        Category category = new Category(_guidGenerator.Create(), "奇幻");
        Book book = new Book(_guidGenerator.Create(), "盗墓笔记", new DateTime(2016, 8, 5), author.Id, author.Name, category.Id, category.Name);
        await WithUnitOfWorkAsync(async () => { await _bookRepository.InsertAsync(book); });
        var result = await WithUnitOfWorkAsync(async () => { return await _bookRepository.FirstOrDefaultAsync(book => book.Id == book.Id); });
        result.ShouldNotBeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Insert_A_Valid_Volume()
    {
        Book book = await _bookRepository.GetAsync(it => it.Name == "三体");
        book.AddVolume("第二卷");
        var result = await WithUnitOfWorkAsync(async () => { return await _bookRepository.UpdateAsync(book); });
        result.Volumes.Count.ShouldBeGreaterThan(1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Insert_A_Valid_Chapter()
    {
        Book book = await _bookRepository.GetAsync(it => it.Name == "三体");
        book.Volumes.Count.ShouldBeGreaterThan(0);
        book.Volumes.First().AddChapter("第二章", "第二章内容");
        var result = await WithUnitOfWorkAsync(async () => { return await _bookRepository.UpdateAsync(book); });
        result.Volumes.First().Chapters.Count.ShouldBeGreaterThan(1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Get_List_Of_Books()
    {
        var result = await WithUnitOfWorkAsync(async () => { return await _bookRepository.GetListAsync(); });
        result.Count.ShouldBeGreaterThan(0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Get_A_Book_Without_Catalog()
    {
        var result = await WithUnitOfWorkAsync(async () => { return await _bookRepository.GetAsync(book => book.Name == "三体"); });
        result.ShouldNotBeNull();
        result.Volumes.Count.ShouldBeGreaterThan(0);
        result.Volumes.First().Chapters.Count.ShouldBeGreaterThan(0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Get_A_Chapter()
    {
        Book book = await _bookRepository.GetAsync(book => book.Name == "三体");
        book.ShouldNotBeNull();
        book.Volumes.Count.ShouldBeGreaterThan(0);
        book.Volumes.First().Chapters.Count.ShouldBeGreaterThan(0);

        Guid chapterId = book.Volumes.First().Chapters.First().Id;
        Chapter? result = await WithUnitOfWorkAsync(async () => { return await _bookRepository.FindChapterByIdAsync(chapterId); });

        result.ShouldNotBeNull();
        result.WordsNumber.ShouldBeGreaterThan(0);
        result.ChapterText.ShouldNotBeNull();
        result.ChapterText.Content.ShouldNotBeNullOrEmpty();
    }
}
