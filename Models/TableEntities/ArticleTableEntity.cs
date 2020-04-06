using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.TableEntities
{
    public class ArticleTableEntity : TableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
