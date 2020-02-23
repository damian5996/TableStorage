using DataAccess.Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleCategoryManager.Queries.GetArticleCategory
{
    internal class GetArticleCategoryHandler : Handler, IRequestHandler<GetArticleCategoryQuery, GetArticleCategoryViewModel>
    {
        public GetArticleCategoryHandler(IArticleCategoryRepository articleCategoryRepository) : base(articleCategoryRepository) { }

        Task<GetArticleCategoryViewModel> IRequestHandler<GetArticleCategoryQuery, GetArticleCategoryViewModel>.Handle(GetArticleCategoryQuery getArticleQuery, CancellationToken cancellationToken)
        {
            var categoryFromDb = _articleCategoryRepository.Get(getArticleQuery.Id).Result;
            var result = new GetArticleCategoryViewModel()
            {
                Id = categoryFromDb.Id,
                Name = categoryFromDb.Name
            };

            return Task.FromResult(result);
            
        }
    }
}
