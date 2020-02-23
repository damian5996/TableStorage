using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ArticleCategoryManagerConfig
{
    public static class ArticleCategoryManagerConfig
    {
        public static IServiceCollection AddArticleCategoryManagerConfig(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
