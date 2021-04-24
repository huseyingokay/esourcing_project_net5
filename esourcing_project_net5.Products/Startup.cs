using esourcing_project_net5.Products.Data;
using esourcing_project_net5.Products.Data.Interfaces;
using esourcing_project_net5.Products.Repositories;
using esourcing_project_net5.Products.Repositories.Interfaces;
using esourcing_project_net5.Products.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace esourcing_project_net5.Products
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<ProductDatabaseSettings>(Configuration.GetSection(nameof(ProductDatabaseSettings)));
            services.AddSingleton<IProductDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value);

            // When we call IProductContext, it will call ProductContext
            services.AddTransient<IProductContext, ProductContext>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "esourcing_project_net5.Products",
                    Version = "v1"
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "esourcing_project_net5.Products v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
