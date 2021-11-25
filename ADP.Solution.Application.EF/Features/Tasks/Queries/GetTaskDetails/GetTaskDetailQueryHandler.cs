using ADP.Solution.Application.Contracts.Persistence;
using ADP.Solution.Application.Exceptions;
using ADP.Solution.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.Solution.Application.Features.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, TaskDetailVm>
    {
        private readonly IAsyncRepository<AdaaTask> _taskRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetTaskDetailQueryHandler(IMapper mapper, IAsyncRepository<AdaaTask> taskRepository, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<TaskDetailVm> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var @task = await _taskRepository.GetByIdAsync(request.Id);
            var taskDetailDto = _mapper.Map<TaskDetailVm>(@task);

            var category = await _categoryRepository.GetByIdAsync(@task.CategoryId);

            if (category == null)
            {
                throw new NotFoundException(nameof(AdaaTask), request.Id);
            }
            taskDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return taskDetailDto;
        }
    }
}
