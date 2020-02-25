using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleCategoryManager.Commands.CreateArticleCategory
{
    public class CreateArticleCategoryCommandValidator : AbstractValidator<CreateArticleCategoryCommand>
    {
        public CreateArticleCategoryCommandValidator()
        {
            RuleFor(x => x.Name).Length(1, 10);
        }
    }
}
