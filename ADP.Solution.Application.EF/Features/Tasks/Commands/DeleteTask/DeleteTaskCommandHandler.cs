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

namespace ADP.Solution.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IAsyncRepository<AdaaTask> _taskRepository;
        private readonly IMapper _mapper;

        public DeleteTaskCommandHandler(IMapper mapper, IAsyncRepository<AdaaTask> taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToDelete = await _taskRepository.GetByIdAsync(request.TaskId);

            if (taskToDelete == null)
            {
                throw new NotFoundException(nameof(AdaaTask), request.TaskId);
            }

            await _taskRepository.DeleteAsync(taskToDelete);

            return Unit.Value;
        }
    }
}
