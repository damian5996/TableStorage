using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleCategoryManager
{
    internal class Handler
    {
        private protected readonly IArticleCategoryRepository _articleCategoryRepository;

        private protected Handler(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
    }
}
