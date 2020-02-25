using MediatR;
using Models;

namespace ArticleCategoryManager.Queries.GetArticleCategory
{
    public class GetArticleCategoryQuery : IRequest<ResponseDto<GetArticleCategoryViewModel>>
    {
        public int Id { get; set; }
    }
}
