using ArticleManager.Queries;
using ArticleManager.Queries.GetArticle;
using DataAccess.Repository.Interfaces;
using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ArticleManager.Queries.GetAllArticles
{
    internal class GetAllArticlesHandler : Handler, IRequestHandler<GetAllArticlesQuery, GetAllArticlesViewModel>
    {
        public GetAllArticlesHandler(IArticleRepository articleRepository) : base(articleRepository) { }

        async Task<GetAllArticlesViewModel> IRequestHandler<GetAllArticlesQuery, GetAllArticlesViewModel>.Handle(GetAllArticlesQuery getArticlesQuery, CancellationToken cancellationToken)
        {
            var articlesFromDb = await _articleRepository.GetAll();
            var result = new GetAllArticlesViewModel {
                Articles = articlesFromDb.Select(x => new GetAllArticlesSingleDto() {
                    Id = x.Id,
                    Content = x.Content,
                    Title = x.Title,
                    Category = new Models.Entities.ArticleCategory() { Id = x.Category.Id, Name = x.Category.Name}
                }).ToList()
            };

            return result;
            
        }
    }
}
