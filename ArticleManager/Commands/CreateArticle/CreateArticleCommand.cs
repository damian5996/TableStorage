﻿using ArticleCategoryManager.Commands.CreateArticle;
using MediatR;
using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManager.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<ResponseDto<string>>
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }

    }
}
