using ArticleCategoryManager.Commands.CreateArticleCategory;
using ArticleCategoryManager.Queries.GetAllArticleCategories;
using ArticleCategoryManager.Queries.GetArticleCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cqrs.Controllers
{
    [Route("api/[controller]")]
    public class ArticleCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories(GetAllArticleCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            if (result.ErrorOccurred) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(GetArticleCategoryQuery query)
        {
            var result = await _mediator.Send(query);
            if (result.ErrorOccurred) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateArticleCategory([FromBody] CreateArticleCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.ErrorOccurred) return BadRequest(result);

            return Ok(result);
        }
    }
}
