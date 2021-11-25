using ADP.Solution.Application.Contracts.Infrastructure;
using ADP.Solution.Application.Features.Tasks.Queries.GetTasksExport;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ADP.Solution.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportTasksToCsv(List<TaskExportDto> taskExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter,Thread.CurrentThread.CurrentCulture, false);
                csvWriter.WriteRecords(taskExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
