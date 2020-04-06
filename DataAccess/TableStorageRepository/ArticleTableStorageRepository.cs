using DataAccess.Configuration;
using DataAccess.TableStorageRepository.Interfaces;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Options;
using Models.TableEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TableStorageRepository
{
    public class ArticleTableStorageRepository : IArticleTableStorageRepository
    {
        private readonly ConnectionStringSettings _connectionStringSettings;
        private CloudTable _articleTable = null;

        public ArticleTableStorageRepository(IOptions<ConnectionStringSettings> accessor)
        {
            _connectionStringSettings = accessor.Value;
            var storageAccount = CloudStorageAccount.Parse(_connectionStringSettings.AzureTableStorage);
            var tableClient = storageAccount.CreateCloudTableClient();
            _articleTable = tableClient.GetTableReference("Articles");
        }
        public IEnumerable<ArticleTableEntity> GetAllFromStorage()
        {
            var query = new TableQuery<ArticleTableEntity>();
            var entities = _articleTable.ExecuteQuery(query);
            return entities;
        }
    }
}
