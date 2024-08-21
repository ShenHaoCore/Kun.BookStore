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

    [Fact]
    public async Task Should_Create_A_Valid_Author()
    {
        var input = new CreateAuthorDto { Name = "南派三叔", Description = "网络文学20年十大悬疑作家" };
        var authorDto = await _authorAppService.CreateAsync(input);
        authorDto.Id.ShouldNotBe(Guid.Empty);
        authorDto.Name.ShouldBe("南派三叔");
    }
}
