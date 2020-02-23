using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManager
{
    internal class Handler
    {
        private protected readonly IArticleRepository _articleRepository;
        private protected readonly IArticleCategoryRepository _articleCategoryRepository;

        private protected Handler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        private protected Handler(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository) : this(articleRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
    }
}
