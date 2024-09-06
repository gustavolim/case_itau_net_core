using Case.Itau.Api.Middlewares;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Case.Itau.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddSwaggerGen(s =>
            {
                s.OperationFilter<SwaggerDefaultValues>();
                s.UseAllOfToExtendReferenceSchemas();

                s.SwaggerDoc("v1.WeatherForecast", new OpenApiInfo
                {
                    Title = "API teste",
                    Version = "v1",
                    Description = "Description",
                    Contact = new OpenApiContact
                    {
                        Email = "delimaalves.gustavo@gmail.com",
                        Name = "Name"
                    }
                });

                s.SwaggerDoc("v1.Fundos", new OpenApiInfo
                {
                    Title = "API Case Itau",
                    Version = "v1",
                    Description = "Description",
                    Contact = new OpenApiContact
                    {
                        Email = "delimaalves.gustavo@gmail.com",
                        Name = "Gustavo de Lima Alves"
                    }
                });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException("app");

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "doc/{documentName}/swagger.json"; 
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "doc";
                c.SwaggerEndpoint("./v1.WeatherForecast/swagger.json", "WeatherForecast");
                c.SwaggerEndpoint("./v1.Fundos/swagger.json", "Fundos");
            });
        }
    }
}
