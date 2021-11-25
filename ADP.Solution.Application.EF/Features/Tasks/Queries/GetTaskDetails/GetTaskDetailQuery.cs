using ADP.Solution.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailQuery : IRequest<TaskDetailVm>
    {
        public Guid Id { get; set; }
    }
}
