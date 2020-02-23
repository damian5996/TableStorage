using Models.Entities;
using System;

namespace Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ArticleCategory Category { get; set; }
    }
}
