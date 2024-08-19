using Kun.BookStore.Authors;
using Kun.BookStore.Books;
using Kun.BookStore.Categories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Kun.BookStore.Data
{
    /// <summary>
    /// 数据播种
    /// </summary>
    public class BookStoreDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Category, Guid> _categoryRepository; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guidGenerator"></param>
        /// <param name="authorRepository"></param>
        /// <param name="bookRepository"></param>
        /// <param name="categoryRepository"></param>
        public BookStoreDataSeedContributor(IGuidGenerator guidGenerator, IRepository<Author, Guid> authorRepository, IRepository<Book, Guid> bookRepository, IRepository<Category, Guid> categoryRepository)
        {
            _guidGenerator = guidGenerator;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateBookAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CreateBookAsync()
        {
            var author = new Author(_guidGenerator.Create(), "刘慈欣", "中国科幻的领军人物");
            await _authorRepository.InsertAsync(author);

            var category = new Category(_guidGenerator.Create(), "科幻");
            await _categoryRepository.InsertAsync(category);

            var book = new Book(_guidGenerator.Create(), "三体", new DateTime(2006, 5, 1), author.Id, author.Name, category.Id, category.Name);
            book.AddVolume("第一卷", "分卷描述");
            book.Volumes.First().AddChapter("第一章", "章节内容");
            await _bookRepository.InsertAsync(book);
        }
    }
}
