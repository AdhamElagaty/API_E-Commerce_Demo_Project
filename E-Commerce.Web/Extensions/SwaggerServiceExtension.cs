using Microsoft.OpenApi.Models;

namespace E_Commerce.Web.Extensions
{
    public static class SwaggerServiceExtension
    {

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "ECommerce API",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Adham",
                            Email = "adhamalagaty@gmail.com",
                            Url = new Uri("https://www.linkedin.com/in/adhamelagaty")
                        }
                    });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement
            {
                { securitySchema, new[] { "Bearer" } }
            };
                options.AddSecurityRequirement(securityRequirement);
            });
            return services;
        }
    }
}
