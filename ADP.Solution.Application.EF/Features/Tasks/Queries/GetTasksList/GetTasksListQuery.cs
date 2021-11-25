using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Tasks.Queries.GetTasksList
{
    public class GetTasksListQuery : IRequest<List<TaskListVm>>
    {
    }
}
