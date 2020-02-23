using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleCategoryManager.Queries.GetAllArticleCategories
{
    public class GetAllArticleCategoriesQuery : IRequest<GetAllArticleCategoriesViewModel>
    {
    }
}
