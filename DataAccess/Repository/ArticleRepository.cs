using DataAccess.Data;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ArticleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Article>> GetAll()
        {
            return _dbContext.Articles.Include(a => a.Category).ToListAsync();
        }

        public Task<Article> Get(int id)
        {
            return _dbContext.Articles.Where(a => a.Id == id).SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Article article)
        {
            await _dbContext.Articles.AddAsync(article);
            await _dbContext.SaveChangesAsync();
            return article.Id;
        }
    }
}
