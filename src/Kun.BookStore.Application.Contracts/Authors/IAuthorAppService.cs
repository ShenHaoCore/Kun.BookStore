using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public interface IAuthorAppService : IApplicationService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AuthorDto> GetAsync(Guid id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<AuthorDto> CreateAsync(CreateAuthorDto input);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAsync(Guid id, UpdateAuthorDto input);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);
}
