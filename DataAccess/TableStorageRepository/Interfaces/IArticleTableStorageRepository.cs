using Models.TableEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.TableStorageRepository.Interfaces
{
    public interface IArticleTableStorageRepository
    {
        IEnumerable<ArticleTableEntity> GetAllFromStorage();
        Task<ArticleTableEntity> GetOneFromStorage(string partitionKey, string rowKey);
        Task<string> Create(ArticleTableEntity entity);
    }
}
