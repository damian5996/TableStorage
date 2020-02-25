using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleCategoryManager.Commands.CreateArticleCategory
{
    public class CreateArticleCategoryCommand : IRequest<ResponseDto<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
