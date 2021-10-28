using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData;
using System.Linq;

namespace wize.resume.odata.Config
{
    public static class ODataMvc
    {
        public static IServiceCollection AddODataMvc(this IServiceCollection services)
        {
            services.AddOData().EnableApiVersioning();

            services.AddODataApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IApplicationBuilder UseODataMvc(this IApplicationBuilder app, VersionedODataModelBuilder builder)
        {
            var edmModels = builder.GetEdmModels();
            app.UseMvc(options =>
            {
                options.EnableDependencyInjection();
                options.Select().Filter().Count().Expand().OrderBy().SkipToken().MaxTop(100);
                options.ServiceProvider.GetRequiredService<ODataOptions>().UrlKeyDelimiter = Microsoft.OData.ODataUrlKeyDelimiter.Parentheses;
                options.MapVersionedODataRoute("odata", "v{version:apiVersion}", edmModels);
            });

            return app;
        }
    }
}
