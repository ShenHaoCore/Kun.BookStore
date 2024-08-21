using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class AuthorAppService : ApplicationService, IAuthorAppService
{
    private readonly IAuthorRepository _authorRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="authorRepository"></param>
    public AuthorAppService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
    {
        Author author = new Author(GuidGenerator.Create(), input.Name, input.Description);
        await _authorRepository.InsertAsync(author);
        return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<AuthorDto> GetAsync(Guid id)
    {
        Author author = await _authorRepository.GetAsync(id);
        return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace()) { input.Sorting = nameof(Author.Name); }
        var list = await _authorRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
        var count = await _authorRepository.GetCountAsync();
        return new PagedResultDto<AuthorDto>(count, ObjectMapper.Map<List<Author>, List<AuthorDto>>(list));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task UpdateAsync(Guid id, UpdateAuthorDto input)
    {
        throw new NotImplementedException();
    }
}
