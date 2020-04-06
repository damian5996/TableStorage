using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ArticleCategoryManager.Commands.CreateArticle;
using ArticleCategoryManager.Commands.CreateArticleCategory;
using ArticleCategoryManagerConfig;
using ArticleManager;
using ArticleManager.Commands.CreateArticle;
using ArticleManager.Queries.GetArticle;
using DataAccess.Configuration;
using DataAccess.Data;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using DataAccess.TableStorageRepository;
using DataAccess.TableStorageRepository.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;

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
            services.AddMvc().AddFluentValidation();

            services.AddArticleManagerConfig();
            services.AddArticleCategoryManagerConfig();

            services.AddDbContext<ApplicationDbContext>();

            services.Configure<ConnectionStringSettings>(Configuration.GetSection("ConnectionStrings"));

            services.AddScoped(typeof(IArticleRepository), typeof(ArticleRepository));
            services.AddScoped(typeof(IArticleCategoryRepository), typeof(ArticleCategoryRepository));

            services.AddScoped(typeof(IArticleTableStorageRepository), typeof(ArticleTableStorageRepository));

            services.AddTransient<IValidator<CreateArticleCommand>, CreateArticleCommandValidator>();

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
