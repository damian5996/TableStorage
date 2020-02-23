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
    internal class CreateArticleHandler : Handler, IRequestHandler<CreateArticleCommand, int>
    {
        public CreateArticleHandler(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository) : base(articleRepository, articleCategoryRepository) { }

        async Task<int> IRequestHandler<CreateArticleCommand, int>.Handle(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            var category = await _articleCategoryRepository.Get(command.CategoryId);
            if (category == null)
            {
                throw new Exception("Wrong category id");
            }
            var article = new Article
            {
                Id = command.Id,
                Content = command.Content,
                Title = command.Title,
                Category = category
            };

            return await _articleRepository.CreateAsync(article);

        }
    }
}
