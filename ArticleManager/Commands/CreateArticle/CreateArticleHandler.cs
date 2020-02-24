using ArticleCategoryManager.Commands.CreateArticle;
using DataAccess.Repository.Interfaces;
using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleManager.Commands.CreateArticle
{
    internal class CreateArticleHandler : Handler, IRequestHandler<CreateArticleCommand, ResponseDto<int>>
    {
        public CreateArticleHandler(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository) : base(articleRepository, articleCategoryRepository) { }

        async Task<ResponseDto<int>> IRequestHandler<CreateArticleCommand, ResponseDto<int>>.Handle(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            var result = Validate<int>(command);
            if (result.ErrorOccurred) return result;

            var category = await _articleCategoryRepository.Get(command.CategoryId);

            if (category == null)
            {
                result.Errors.Add("Category not found.");
                return result;
            }

            var article = new Article
            {
                Id = command.Id,
                Content = command.Content,
                Title = command.Title,
                Category = category
            };

            result.Object = await _articleRepository.CreateAsync(article);

            return result;
        }

        private static ResponseDto<T> Validate<T>(CreateArticleCommand command)
        {
            var response = new ResponseDto<T>();
            CreateArticleCommandValidator validator = new CreateArticleCommandValidator();

            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
            }
            return response;
        }
    }
}
