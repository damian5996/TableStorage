using DataAccess.Repository.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleCategoryManager.Queries.GetAllArticleCategories
{
    internal class GetAllArticleCategoriesHandler : Handler, IRequestHandler<GetAllArticleCategoriesQuery, GetAllArticleCategoriesViewModel>
    {
        public GetAllArticleCategoriesHandler(IArticleCategoryRepository articleCategoryRepository) : base(articleCategoryRepository) { }

        async Task<GetAllArticleCategoriesViewModel> IRequestHandler<GetAllArticleCategoriesQuery, GetAllArticleCategoriesViewModel>.Handle(GetAllArticleCategoriesQuery getArticlesQuery, CancellationToken cancellationToken)
        {
            var categoriesFromDb = await _articleCategoryRepository.GetAll();
            var result = new GetAllArticleCategoriesViewModel {
                Categories = categoriesFromDb.Select(x => new GetAllArticleCategoriesSingleDto() {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return result;
            
        }
    }
}
