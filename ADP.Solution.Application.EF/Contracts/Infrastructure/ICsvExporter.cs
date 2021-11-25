using ADP.Solution.Application.Features.Tasks.Queries.GetTasksExport;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportTasksToCsv(List<TaskExportDto> taskExportDtos);
    }
}
