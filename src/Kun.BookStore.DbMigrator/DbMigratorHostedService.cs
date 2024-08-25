using Kun.BookStore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.Data;

namespace Kun.BookStore.DbMigrator;

/// <summary>
/// 
/// </summary>
public class DbMigratorHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// 
    /// </summary>
    public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var application = await AbpApplicationFactory.CreateAsync<BookStoreDbMigratorModule>(options =>
        {
            options.UseAutofac();
            options.AddDataMigrationEnvironment();
        }))
        {
            await application.InitializeAsync();
            await application.ServiceProvider.GetRequiredService<BookStoreDbMigrationService>().MigrateAsync();
            await application.ShutdownAsync();
            _hostApplicationLifetime.StopApplication();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
