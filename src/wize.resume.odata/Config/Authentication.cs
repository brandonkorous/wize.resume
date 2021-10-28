using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace wize.resume.odata.Config
{
    public static class Authentication
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            JwtModel jwt = new JwtModel();
            jwt.ValidAudience = configuration.GetValue<string>("JwtAuthentication_ValidAudience");
            jwt.ValidIssuer = configuration.GetValue<string>("JwtAuthentication_ValidIssuer");

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true;
                options.RequireHttpsMetadata = false;
                options.Authority = jwt.ValidIssuer;
                options.Audience = jwt.ValidAudience;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:resume", policy => policy.Requirements.Add(new HasPermissionsRequirement("read:resume", jwt.ValidIssuer)));
                options.AddPolicy("add:resume", policy => policy.Requirements.Add(new HasPermissionsRequirement("add:resume", jwt.ValidIssuer)));
                options.AddPolicy("list:resume", policy => policy.Requirements.Add(new HasPermissionsRequirement("list:resume", jwt.ValidIssuer)));
                options.AddPolicy("update:resume", policy => policy.Requirements.Add(new HasPermissionsRequirement("update:resume", jwt.ValidIssuer)));
                options.AddPolicy("delete:resume", policy => policy.Requirements.Add(new HasPermissionsRequirement("delete:resume", jwt.ValidIssuer)));
            });
            services.AddSingleton<IAuthorizationHandler, HasPermissionsHandler>();

            return services;
        }

        public static IApplicationBuilder UseJwt(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}
