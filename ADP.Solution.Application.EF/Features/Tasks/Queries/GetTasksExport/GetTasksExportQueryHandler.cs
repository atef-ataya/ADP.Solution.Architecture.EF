using ADP.Solution.Application.Contracts.Infrastructure;
using ADP.Solution.Application.Contracts.Persistence;
using ADP.Solution.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.Solution.Application.Features.Tasks.Queries.GetTasksExport
{
    public class GetTasksExportQueryHandler : IRequestHandler<GetTasksExportQuery, TaskExportFileVm>
    {
        private readonly IAsyncRepository<AdaaTask> _taskRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetTasksExportQueryHandler(IMapper mapper, IAsyncRepository<AdaaTask> taskRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _csvExporter = csvExporter;
        }

        public async Task<TaskExportFileVm> Handle(GetTasksExportQuery request, CancellationToken cancellationToken)
        {
            var allTasks = _mapper.Map<List<TaskExportDto>>((await _taskRepository.ListAllAsync()).OrderBy(x => x.Date));

            var fileData = _csvExporter.ExportTasksToCsv(allTasks);

            var TaskExportFileDto = new TaskExportFileVm() { ContentType = "text/csv", Data = fileData, TaskExportFileName = $"{Guid.NewGuid()}.csv" };

            return TaskExportFileDto;
        }
    }
}
