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

namespace ArticleManager.Queries.GetArticle
{
    internal class GetArticleHandler : Handler, IRequestHandler<GetArticleQuery, ResponseDto<GetArticleViewModel>>
    {
        public GetArticleHandler(IArticleRepository articleRepository) : base(articleRepository) { }

        async Task<ResponseDto<GetArticleViewModel>> IRequestHandler<GetArticleQuery, ResponseDto<GetArticleViewModel>>.Handle(GetArticleQuery getArticleQuery, CancellationToken cancellationToken)
        {
            var result = new ResponseDto<GetArticleViewModel>();
            var articleFromDb = await _articleRepository.Get(getArticleQuery.Id);
            result.Object = new GetArticleViewModel()
            {
                Id = articleFromDb.Id,
                Content = articleFromDb.Content,
                Title = articleFromDb.Title,
                Category = articleFromDb.Category
            };

            return result;
            
        }
    }
}
