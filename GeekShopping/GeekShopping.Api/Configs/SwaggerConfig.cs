﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;

namespace GeekShopping.Api.Configs
{
    public static class ConfigureSwagger
    {
        public static void AddSwaggerGenConfig(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(opt => {

                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;

            }).AddApiVersioning(opt => {

                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;

            });

            var apiProviderDescription = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(
                opt =>
                {
                    foreach (var descriptions in apiProviderDescription.ApiVersionDescriptions)
                    {
                        opt.SwaggerDoc(
                                        descriptions.GroupName,
                                        new Microsoft.OpenApi.Models.OpenApiInfo()
                                        {
                                            Title = "GeekShopping Api",
                                            Version = descriptions.ApiVersion.ToString(),
                                            Contact = new Microsoft.OpenApi.Models.OpenApiContact
                                            {
                                                Name = "Rafael F Cunha",
                                                Email = "rafa_fernandes_cunha@hotmail.com"
                                            }
                                        });
                    }

                    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                    opt.IncludeXmlComments(xmlCommentsFullPath);
                });
        }

        public static void AddUseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            app.UseSwagger()
                            .UseSwaggerUI(
                            opt =>
                            {
                                foreach (var descriptions in apiVersionDescriptionProvider.ApiVersionDescriptions)
                                {
                                    opt.SwaggerEndpoint($"swagger/{descriptions.GroupName}/swagger.api.json", descriptions.GroupName.ToUpperInvariant());
                                    opt.RoutePrefix = "";
                                }


                            });
        }

    }
}
