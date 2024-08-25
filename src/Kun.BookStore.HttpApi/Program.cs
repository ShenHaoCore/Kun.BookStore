using Kun.BookStore.HttpApi;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
await builder.Services.AddApplicationAsync<BookStoreHttpApiModule>();

var app = builder.Build();
await app.InitializeApplicationAsync();
app.Run();
