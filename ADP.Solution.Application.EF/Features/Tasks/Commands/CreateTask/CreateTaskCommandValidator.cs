using FluentValidation;
using ADP.Solution.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.Solution.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        private readonly ITasksRepository _taskRepository;
        public CreateTaskCommandValidator(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
            
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
                .MustAsync(TaskNameAndDateUnique)
                .WithMessage("An task with the same name and date already exists.");
        }

        private async Task<bool> TaskNameAndDateUnique(CreateTaskCommand e, CancellationToken token)
        {
            return !(await _taskRepository.IsTaskNameAndDateUnique(e.Name, e.Date));
        }
    }
}
