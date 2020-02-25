using DataAccess.Repository.Interfaces;
using FluentValidation;
using MediatR;
using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleCategoryManager.Commands.CreateArticleCategory
{
    internal class CreateArticleCategoryHandler : Handler, IRequestHandler<CreateArticleCategoryCommand, ResponseDto<int>>
    {
        public CreateArticleCategoryHandler(IArticleCategoryRepository articleCategoryRepository) : base(articleCategoryRepository) { }

        async Task<ResponseDto<int>> IRequestHandler<CreateArticleCategoryCommand, ResponseDto<int>>.Handle(CreateArticleCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = Validate<int, CreateArticleCategoryCommandValidator, CreateArticleCategoryCommand>(command);
            if (result.ErrorOccurred) return result;

            var category = new ArticleCategory
            {
                Id = command.Id,
                Name = command.Name
            };

            result.Object = await _articleCategoryRepository.CreateAsync(category);

            return result;
        }

    }
}
