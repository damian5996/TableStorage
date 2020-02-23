using MediatR;

namespace ArticleCategoryManager.Queries.GetArticleCategory
{
    public class GetArticleCategoryQuery : IRequest<GetArticleCategoryViewModel>
    {
        public int Id { get; set; }
    }
}
