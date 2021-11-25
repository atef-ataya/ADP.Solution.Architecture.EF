﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public Guid TaskId { get; set; }
    }
}
