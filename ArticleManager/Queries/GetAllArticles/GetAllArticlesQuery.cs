using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManager.Queries.GetAllArticles
{
    public class GetAllArticlesQuery : IRequest<GetAllArticlesViewModel>
    {
    }
}
