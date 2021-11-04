using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using wize.common.tenancy;
using wize.common.tenancy.Interfaces;
using wize.common.tenancy.Providers;
using wize.resume.data;
using wize.resume.data.V1;
using wize.resume.odata.Config;

namespace wize.resume.odata
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddApiVersioning(options => options.ReportApiVersions = true);

            services.AddJwt(Configuration);
            services.AddODataMvc();
            
            services.AddOpenAPI();
            
            services.AddHttpContextAccessor();
            services.AddTransient<ITenantProvider, TenantDatabaseProvider>();
            services.AddDbContext<WizeContext>(options =>
            {
                options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings_WizeWorksContext"));
            });
            services.AddDbContext<TenantContext>(options =>
            {
                options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings_TenantsContext"));
            });
            services.AddApplicationInsightsTelemetry(Configuration.GetValue<string>("ApplicationInsights_ConnectionString"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider, VersionedODataModelBuilder builder)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            app.UseJwt();

            app.UseRouting();
            app.UseSentryTracing();

            app.UseOpenAPI(provider);
            app.UseODataMvc(builder);
        }
    }
}
