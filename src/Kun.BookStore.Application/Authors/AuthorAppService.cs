using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kun.BookStore.Authors;

/// <summary>
/// 
/// </summary>
public class AuthorAppService : ApplicationService, IAuthorAppService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly AuthorManager _authorManager;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="authorRepository"></param>
    /// <param name="authorManager"></param>
    public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
    {
        _authorRepository = authorRepository;
        _authorManager = authorManager;
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
    public async Task DeleteAsync(Guid id)
    {
        await _authorRepository.DeleteAsync(id);
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
    public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace()) { input.Sorting = nameof(Author.Name); }
        List<Author> list = await _authorRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
        long count = await _authorRepository.GetCountAsync();
        return new PagedResultDto<AuthorDto>(count, ObjectMapper.Map<List<Author>, List<AuthorDto>>(list));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
    {
        Author author = await _authorRepository.GetAsync(id);
        if (author.Name != input.Name) { await _authorManager.ChangeNameAsync(author, input.Name); }
        author.Description = input.Description;
        await _authorRepository.UpdateAsync(author);
    }
}
