using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Tasks.Queries.GetTasksExport
{
    public class GetTasksExportQuery: IRequest<TaskExportFileVm>
    {
    }
}
