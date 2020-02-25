using DataAccess.Repository.Interfaces;
using MediatR;
using Models;
using System.Threading;
using System.Threading.Tasks;

namespace ArticleCategoryManager.Queries.GetArticleCategory
{
    internal class GetArticleCategoryHandler : Handler, IRequestHandler<GetArticleCategoryQuery, ResponseDto<GetArticleCategoryViewModel>>
    {
        public GetArticleCategoryHandler(IArticleCategoryRepository articleCategoryRepository) : base(articleCategoryRepository) { }

        async Task<ResponseDto<GetArticleCategoryViewModel>> IRequestHandler<GetArticleCategoryQuery, ResponseDto<GetArticleCategoryViewModel>>.Handle(GetArticleCategoryQuery getArticleQuery, CancellationToken cancellationToken)
        {
            var result = new ResponseDto<GetArticleCategoryViewModel>();
            var categoryFromDb = await _articleCategoryRepository.Get(getArticleQuery.Id);
            result.Object = new GetArticleCategoryViewModel()
            {
                Id = categoryFromDb.Id,
                Name = categoryFromDb.Name
            };

            return result;
            
        }
    }
}
