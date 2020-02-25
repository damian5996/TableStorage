using DataAccess.Repository.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleCategoryManager
{
    internal class Handler : Validator
    {
        private protected readonly IArticleCategoryRepository _articleCategoryRepository;

        private protected Handler(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
    }
}
