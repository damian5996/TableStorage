using DataAccess.Repository.Interfaces;
using MediatR;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleCategoryManager.Commands.CreateArticleCategory
{
    internal class CreateArticleCategoryHandler : Handler, IRequestHandler<CreateArticleCategoryCommand, int>
    {
        public CreateArticleCategoryHandler(IArticleCategoryRepository articleCategoryRepository) : base(articleCategoryRepository) { }

        Task<int> IRequestHandler<CreateArticleCategoryCommand, int>.Handle(CreateArticleCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new ArticleCategory
            {
                Id = command.Id,
                Name = command.Name
            };

            return _articleCategoryRepository.CreateAsync(category);

        }
    }
}
