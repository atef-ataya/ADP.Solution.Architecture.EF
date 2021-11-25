using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Task name: {Name}; On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
