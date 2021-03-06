﻿using ArticleManager.Queries;
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
using DataAccess.TableStorageRepository.Interfaces;

namespace ArticleManager.Queries.GetAllArticles
{
    internal class GetAllArticlesHandler : Handler, IRequestHandler<GetAllArticlesQuery, ResponseDto<GetAllArticlesViewModel>>
    {
        public GetAllArticlesHandler(IArticleRepository articleRepository, IArticleTableStorageRepository articleStorageRepository) : base(articleRepository, articleStorageRepository) { }

        Task<ResponseDto<GetAllArticlesViewModel>> IRequestHandler<GetAllArticlesQuery, ResponseDto<GetAllArticlesViewModel>>.Handle(GetAllArticlesQuery getArticlesQuery, CancellationToken cancellationToken)
        {
            var result = new ResponseDto<GetAllArticlesViewModel>();
            var articlesFromDb = _articleTableStorageRepository.GetAllFromStorage();
            result.Object = new GetAllArticlesViewModel {
                Articles = articlesFromDb.Select(x => new GetAllArticlesSingleDto() {
                    PartitionKey = x.PartitionKey,
                    RowKey = x.RowKey,
                    Content = x.Content,
                    Title = x.Title
                }).ToList()
            };

            return Task.FromResult(result);
            
        }
    }
}
