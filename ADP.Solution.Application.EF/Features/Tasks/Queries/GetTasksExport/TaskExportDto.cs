using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Tasks.Queries.GetTasksExport
{
    public class TaskExportDto
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
