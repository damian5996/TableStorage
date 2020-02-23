using ArticleManager.Commands.CreateArticle;
using ArticleManager.Queries.GetAllArticles;
using ArticleManager.Queries.GetArticle;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cqrs.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<GetAllArticlesViewModel> GetAllArticles(GetAllArticlesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<GetArticleViewModel> GetArticle([FromRoute] GetArticleQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}