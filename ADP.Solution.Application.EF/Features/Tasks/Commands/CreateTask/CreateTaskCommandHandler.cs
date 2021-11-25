using ADP.Solution.Application.Contracts.Persistence;
using ADP.Solution.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.Solution.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITasksRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTaskCommandHandler> _logger;


        public CreateTaskCommandHandler(IMapper mapper, ITasksRepository taskRepository, ILogger<CreateTaskCommandHandler> logger)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTaskCommandValidator(_taskRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var task = _mapper.Map<AdaaTask>(request);

            task = await _taskRepository.AddAsync(task);

            return task.TaskId;
        }
    }
}
