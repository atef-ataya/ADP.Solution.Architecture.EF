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

namespace ADP.Solution.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IAsyncRepository<AdaaTask> _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IMapper mapper, IAsyncRepository<AdaaTask> taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {

            var taskToUpdate = await _taskRepository.GetByIdAsync(request.TaskId);

            if (taskToUpdate == null)
            {
                throw new NotFoundException(nameof(AdaaTask), request.TaskId);
            }

            var validator = new UpdateTaskCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, taskToUpdate, typeof(UpdateTaskCommand), typeof(AdaaTask));

            await _taskRepository.UpdateAsync(taskToUpdate);

            return Unit.Value;
        }
    }
}
