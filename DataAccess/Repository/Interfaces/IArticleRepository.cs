using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAll();
        Task<Article> Get(int id);
        Task<int> CreateAsync(Article article);
    }
}
