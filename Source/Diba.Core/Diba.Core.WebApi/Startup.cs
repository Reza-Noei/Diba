using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Diba.Core.AppService;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Order;
using Diba.Core.AppService.Contract.Product;
using Diba.Core.AppService.Contract.ProductConstraint;
using Diba.Core.AppService.CustomerManagement;
using Diba.Core.AppService.Dependencies;
using Diba.Core.AppService.Order;
using Diba.Core.AppService.ProductConstraint;
using Diba.Core.AppService.Products;
using Diba.Core.AppService.RequestItem;
using Diba.Core.Data.Repository.Implementations;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.WebApi.Internal.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Diba.Core.Service
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.ModelValidatorProviders.Clear()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IOrdersCommandService, OrdersCommandService>();

            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<IProductQueryService, ProductQueryService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductStringConstraintsQueryService, ProductStringConstraintsQueryService>();
            services.AddScoped<IProductStringConstraintsCommandService, ProductStringConstraintsCommandService>();
            services.AddScoped<IProductStringConstraintsRepository, ProductStringConstraintsRepository>();

            services.AddScoped<IProductSelectiveConstraintsQueryService, ProductSelectiveConstraintsQueryService>();
            services.AddScoped<IProductSelectiveConstraintsCommandService, ProductSelectiveConstraintsCommandService>();
            services.AddScoped<IProductSelectiveConstraintsRepository, ProductSelectiveConstraintsRepository>();

            services.AddFromConfigurationFile(Configuration.GetSection("Services"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer();

            services.AddAuthorization(config => { });
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            //IAuthenticationCommand authenticationCommand = serviceProvider.GetService<IAuthenticationCommand>();
            IPermissionQuery permissionQuery = serviceProvider.GetService<IPermissionQuery>();
            IAuthenticationQuery authenticationQuery = serviceProvider.GetService<IAuthenticationQuery>();
            IAuthenticationInformation authenticationInformation = serviceProvider.GetService<IAuthenticationInformation>();

            services.AddControllers(config =>
            {
                config.Filters.Add(new AuthenticationFilter(authenticationInformation, authenticationQuery, permissionQuery));
                //config.Filters.Add(new ActionFilterExample());
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RoleMappingProfile());
                mc.AddProfile(new UserManagementMappingProfile());
                mc.AddProfile(new CustomerManagementMappingProfile());
                mc.AddProfile(new OrganizationManagementMappingProfile());
                mc.AddProfile(new ProductMappingConfig());
                mc.AddProfile(new ProductStringConstraintsConfig());
                mc.AddProfile(new ProductSelectiveConstraintsConfig());
                mc.AddProfile(new OrderMappingConfig());
                mc.AddProfile(new OrderMappingConfig());
                mc.AddProfile(new RequestItemMappingConfig());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //app.UseSwagger(c => {
            //    c.SerializeAsV2 = true;
            //});

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            //app.UseMiddleware<JwtMiddleware>();
            //app.UseAuthorization();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
