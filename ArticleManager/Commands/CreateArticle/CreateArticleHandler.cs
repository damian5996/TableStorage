using ArticleCategoryManager.Commands.CreateArticle;
using DataAccess.Repository.Interfaces;
using DataAccess.TableStorageRepository.Interfaces;
using MediatR;
using Models;
using Models.TableEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleManager.Commands.CreateArticle
{
    internal class CreateArticleHandler : Handler, IRequestHandler<CreateArticleCommand, ResponseDto<string>>
    {
        public CreateArticleHandler(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository, IArticleTableStorageRepository articleStorageRepository) : base(articleRepository, articleCategoryRepository, articleStorageRepository) { }

        async Task<ResponseDto<string>> IRequestHandler<CreateArticleCommand, ResponseDto<string>>.Handle(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            var result = Validate<string, CreateArticleCommandValidator, CreateArticleCommand>(command);
            if (result.ErrorOccurred) 
                return result;

            var article = new ArticleTableEntity
            {
                PartitionKey = command.PartitionKey,
                RowKey = Guid.NewGuid().ToString(),
                Content = command.Content,
                Title = command.Title
            };

            result.Object = await _articleTableStorageRepository.Create(article);

            return result;
        }
    }
}
