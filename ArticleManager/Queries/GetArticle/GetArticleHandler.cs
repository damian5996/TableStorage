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
    internal class GetArticleHandler : Handler, IRequestHandler<GetArticleQuery, GetArticleViewModel>
    {
        public GetArticleHandler(IArticleRepository articleRepository) : base(articleRepository) { }

        Task<GetArticleViewModel> IRequestHandler<GetArticleQuery, GetArticleViewModel>.Handle(GetArticleQuery getArticleQuery, CancellationToken cancellationToken)
        {
            var articleFromDb = _articleRepository.Get(getArticleQuery.Id).Result;
            var result = new GetArticleViewModel()
            {
                Id = articleFromDb.Id,
                Content = articleFromDb.Content,
                Title = articleFromDb.Title,
                Category = articleFromDb.Category
            };

            return Task.FromResult(result);
            
        }
    }
}
