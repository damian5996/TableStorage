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
        public async Task<GetAllArticleCategoriesViewModel> GetAllCategories(GetAllArticleCategoriesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<GetArticleCategoryViewModel> GetCategory(GetArticleCategoryQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateArticleCategory([FromBody] CreateArticleCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
