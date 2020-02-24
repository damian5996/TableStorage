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
using Models.Entities;

namespace ArticleManager.Queries.GetAllArticles
{
    internal class GetAllArticlesHandler : Handler, IRequestHandler<GetAllArticlesQuery, ResponseDto<GetAllArticlesViewModel>>
    {
        public GetAllArticlesHandler(IArticleRepository articleRepository) : base(articleRepository) { }

        async Task<ResponseDto<GetAllArticlesViewModel>> IRequestHandler<GetAllArticlesQuery, ResponseDto<GetAllArticlesViewModel>>.Handle(GetAllArticlesQuery getArticlesQuery, CancellationToken cancellationToken)
        {
            var result = new ResponseDto<GetAllArticlesViewModel>();
            var articlesFromDb = await _articleRepository.GetAll();
            result.Object = new GetAllArticlesViewModel {
                Articles = articlesFromDb.Select(x => new GetAllArticlesSingleDto() {
                    Id = x.Id,
                    Content = x.Content,
                    Title = x.Title,
                    Category = new ArticleCategory() { Id = x.Category.Id, Name = x.Category.Name}
                }).ToList()
            };

            return result;
            
        }
    }
}
