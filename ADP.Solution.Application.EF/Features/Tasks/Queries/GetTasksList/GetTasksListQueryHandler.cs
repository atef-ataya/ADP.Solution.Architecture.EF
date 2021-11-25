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

namespace ADP.Solution.Application.Features.Tasks.Queries.GetTasksList
{
    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, List<TaskListVm>>
    {
        private readonly IAsyncRepository<AdaaTask> _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksListQueryHandler(IMapper mapper, IAsyncRepository<AdaaTask> taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskListVm>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            var allTasks = (await _taskRepository.ListAllAsync()).OrderBy(x => x.Date);
            return _mapper.Map<List<TaskListVm>>(allTasks);
        }
    }
}
