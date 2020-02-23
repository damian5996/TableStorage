using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleCategoryManager.Commands.CreateArticleCategory
{
    public class CreateArticleCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
