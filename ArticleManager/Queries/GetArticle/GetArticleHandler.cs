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
using DataAccess.TableStorageRepository.Interfaces;

namespace ArticleManager.Queries.GetArticle
{
    internal class GetArticleHandler : Handler, IRequestHandler<GetArticleQuery, ResponseDto<GetArticleViewModel>>
    {
        public GetArticleHandler(IArticleRepository articleRepository, IArticleTableStorageRepository articleStorageRepository) : base(articleRepository, articleStorageRepository) { }

        async Task<ResponseDto<GetArticleViewModel>> IRequestHandler<GetArticleQuery, ResponseDto<GetArticleViewModel>>.Handle(GetArticleQuery getArticleQuery, CancellationToken cancellationToken)
        {
            var result = new ResponseDto<GetArticleViewModel>();
            var articleFromDb = await _articleTableStorageRepository.GetOneFromStorage(getArticleQuery.PartitionKey, getArticleQuery.RowKey);
            if(articleFromDb == null)
            {
                result.Errors.Add("Article not found");
                return result;
            }
            result.Object = new GetArticleViewModel()
            {
                PartitionKey = articleFromDb.PartitionKey,
                RowKey = articleFromDb.RowKey,
                Content = articleFromDb.Content,
                Title = articleFromDb.Title
            };

            return result;
            
        }
    }
}
