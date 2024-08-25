using Kun.BookStore.Application.Contracts;
using Kun.BookStore.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Kun.BookStore.HttpApi;

/// <summary>
/// 
/// </summary>
[DependsOn(typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(BookStoreApplicationModule))]
[DependsOn(typeof(BookStoreEntityFrameworkCoreModule))]
public class BookStoreHttpApiModule : AbpModule
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAspNetCoreMvcOptions>(options => { options.ConventionalControllers.Create(typeof(BookStoreApplicationModule).Assembly); });
        context.Services.AddAbpSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
            options.DocInclusionPredicate((docName, description) => true);
            options.CustomSchemaIds(type => type.FullName);
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API");
            options.DocExpansion(DocExpansion.None); // 设置为 None 可折叠所有方法
            options.DefaultModelsExpandDepth(0); // 设置为 -1 可不显示Models
            options.DisplayRequestDuration(); // 设置持续时间的显示（以毫秒为单位）
        });

        app.UseConfiguredEndpoints();
    }
}
