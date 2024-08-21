using AutoMapper;
using Kun.BookStore.Authors;

namespace Kun.BookStore;

/// <summary>
/// 
/// </summary>
public class BookStoreApplicationAutoMapperProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Author, AuthorDto>();
    }
}
