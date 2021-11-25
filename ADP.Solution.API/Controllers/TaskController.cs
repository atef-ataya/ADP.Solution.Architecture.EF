using ADP.Solution.API.Utility;
using ADP.Solution.Application.Contracts.Identity;
using ADP.Solution.Application.Features.Tasks.Commands.CreateTask;
using ADP.Solution.Application.Features.Tasks.Commands.DeleteTask;
using ADP.Solution.Application.Features.Tasks.Commands.UpdateTask;
using ADP.Solution.Application.Features.Tasks.Queries.GetTaskDetails;
using ADP.Solution.Application.Features.Tasks.Queries.GetTasksExport;
using ADP.Solution.Application.Features.Tasks.Queries.GetTasksList;
using ADP.Solution.Application.Models.Authenticaiton;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADP.Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<TaskListVm>>> GetAllTasks()
        {
            var dtos = await _mediator.Send(new GetTasksListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<ActionResult<TaskDetailVm>> GetTaskById(Guid id)
        {
            var getTaskDetailQuery = new GetTaskDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getTaskDetailQuery));
        }

        [HttpPost(Name = "AddTask")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskCommand createTaskCommand)
        {
            var id = await _mediator.Send(createTaskCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTaskCommand updateTaskCommand)
        {
            await _mediator.Send(updateTaskCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteTaskCommand = new DeleteTaskCommand() { TaskId = id };
            await _mediator.Send(deleteTaskCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportTasks")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportTasks()
        {
            var fileDto = await _mediator.Send(new GetTasksExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.TaskExportFileName);
        }
    }
}
