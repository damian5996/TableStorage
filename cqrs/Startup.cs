using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ArticleCategoryManagerConfig;
using ArticleManager;
using ArticleManager.Queries.GetArticle;
using DataAccess.Configuration;
using DataAccess.Data;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cqrs
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

            services.AddArticleManagerConfig();
            services.AddArticleCategoryManagerConfig();

            services.AddDbContext<ApplicationDbContext>();

            services.Configure<ConnectionStringSettings>(Configuration.GetSection("ConnectionStrings"));

            services.AddScoped(typeof(IArticleRepository), typeof(ArticleRepository));
            services.AddScoped(typeof(IArticleCategoryRepository), typeof(ArticleCategoryRepository));

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
