using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
