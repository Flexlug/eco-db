using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using eco_db_backend.Constants;
using eco_db_backend.Services;
using eco_db_backend.Models;


namespace eco_db_backend
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
            services.Configure<ProductsDatabaseSettings>(
                Configuration.GetSection(nameof(ProductsDatabaseSettings)));

            services.AddSingleton<IProductsDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ProductsDatabaseSettings>>().Value);

            services.AddSingleton<ProductService>();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing());

            UpdateDBCredentials();
        }

        // Updates DB credentials from environment variables
        public void UpdateDBCredentials()
        {
            DbCredentials.HOST = @Environment.GetEnvironmentVariable("DB_HOST");
            DbCredentials.DATABASE = @Environment.GetEnvironmentVariable("DB_DATABASE");
            DbCredentials.USER = @Environment.GetEnvironmentVariable("DB_USER");
            DbCredentials.PORT = @Environment.GetEnvironmentVariable("DB_PORT");
            DbCredentials.PASSWORD = @Environment.GetEnvironmentVariable("DB_PASSWORD");
            DbCredentials.URI = @Environment.GetEnvironmentVariable("DB_URI");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
