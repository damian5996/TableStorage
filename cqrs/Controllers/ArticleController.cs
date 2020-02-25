using ArticleManager.Commands.CreateArticle;
using ArticleManager.Queries.GetAllArticles;
using ArticleManager.Queries.GetArticle;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        public async Task<IActionResult> GetAllArticles(GetAllArticlesQuery query)
        {
            var result = await _mediator.Send(query);
            if (result.ErrorOccurred) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] GetArticleQuery query)
        {
            var result = await _mediator.Send(query);
            if (result.ErrorOccurred) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.ErrorOccurred) return BadRequest(result);

            return Ok(result);
        }

    }
}