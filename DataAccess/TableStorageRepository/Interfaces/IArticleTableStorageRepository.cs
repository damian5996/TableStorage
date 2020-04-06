using Models.TableEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TableStorageRepository.Interfaces
{
    public interface IArticleTableStorageRepository
    {
        IEnumerable<ArticleTableEntity> GetAllFromStorage();
    }
}
