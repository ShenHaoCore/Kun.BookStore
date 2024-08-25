using Shouldly;
using Volo.Abp.Guids;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class AuthorAppServiceTests : BookStoreApplicationTestBase
{
    private readonly IAuthorAppService _authorAppService;

    /// <summary>
    /// 
    /// </summary>
    public AuthorAppServiceTests()
    {
        _authorAppService = GetRequiredService<IAuthorAppService>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Create_A_Valid_Author()
    {
        var input = new CreateAuthorDto { Name = "南派三叔", Description = "网络文学20年十大悬疑作家" };
        await WithUnitOfWorkAsync(async () => { await Should.NotThrowAsync(async () => { await _authorAppService.CreateAsync(input); }); });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Should_Get_PagedAndSorted_Of_Authors()
    {
            var input = new GetAuthorListDto() { SkipCount = 0, MaxResultCount = 10, Sorting = "Name" };
        var result = await WithUnitOfWorkAsync(async () => { return await _authorAppService.GetListAsync(input); });
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.Count.ShouldBeGreaterThan(0);
    }
}
