using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManager.Queries.GetArticle
{
    public class GetArticleQuery : IRequest<ResponseDto<GetArticleViewModel>>
    {
        public int Id { get; set; }
    }
}
