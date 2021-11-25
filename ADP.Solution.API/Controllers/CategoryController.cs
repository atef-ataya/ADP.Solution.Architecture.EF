using ADP.Solution.Application.Features.Categories.Commands.CreateCategory;
using ADP.Solution.Application.Features.Categories.Queries.GetCategoriesList;
using ADP.Solution.Application.Features.Categories.Queries.GetCategoriesListWithTasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADP.Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery() { BypassCache = false });
            return Ok(dtos);
        }

        [Authorize]
        [HttpGet("allwithtasks", Name = "GetCategoriesWithTasks")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryTasksListVm>>> GetCategoriesWithTasks()
        {
            GetCategoriesListWithTasksQuery getCategoriesListWithTasksQuery = new GetCategoriesListWithTasksQuery();

            var dtos = await _mediator.Send(getCategoriesListWithTasksQuery);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
