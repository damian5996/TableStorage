using DataAccess.Repository.Interfaces;
using MediatR;
using Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleCategoryManager.Queries.GetAllArticleCategories
{
    internal class GetAllArticleCategoriesHandler : Handler, IRequestHandler<GetAllArticleCategoriesQuery, ResponseDto<GetAllArticleCategoriesViewModel>>
    {
        public GetAllArticleCategoriesHandler(IArticleCategoryRepository articleCategoryRepository) : base(articleCategoryRepository) { }

        async Task<ResponseDto<GetAllArticleCategoriesViewModel>> IRequestHandler<GetAllArticleCategoriesQuery, ResponseDto<GetAllArticleCategoriesViewModel>>.Handle(GetAllArticleCategoriesQuery getArticlesQuery, CancellationToken cancellationToken)
        {
            var result = new ResponseDto<GetAllArticleCategoriesViewModel>();
            var categoriesFromDb = await _articleCategoryRepository.GetAll();
            result.Object = new GetAllArticleCategoriesViewModel {
                Categories = categoriesFromDb.Select(x => new GetAllArticleCategoriesSingleDto() {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return result;
            
        }
    }
}
