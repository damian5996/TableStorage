using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManager.Queries.GetArticle
{
    public class GetArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ArticleCategory Category { get; set; }
    }
}
