﻿using Kun.BookStore.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public sealed class AuthorRepositoryTests : BookStoreEntityFrameworkCoreTestBase
{
    private readonly IAuthorRepository _authorRepository; 
    private readonly IGuidGenerator _guidGenerator;

    /// <summary>
    /// 
    /// </summary>
    public AuthorRepositoryTests()
    {
        _authorRepository = GetRequiredService<IAuthorRepository>();
        _guidGenerator = GetRequiredService<IGuidGenerator>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Insert_A_Valid_Author()
    {
        var testAuthor = new Author(_guidGenerator.Create(), "刘慈欣", "中国科幻的领军人物");
        await WithUnitOfWorkAsync(async () => { await _authorRepository.InsertAsync(testAuthor); });
        var result = await WithUnitOfWorkAsync(async () => { return await _authorRepository.FirstOrDefaultAsync(author => author.Id == testAuthor.Id); });
        result.ShouldNotBeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Get_List_Of_Author()
    {
        var result = await WithUnitOfWorkAsync(async () => { return await _authorRepository.GetListAsync(); });
        result.Count.ShouldBeGreaterThan(0);
    }
}
