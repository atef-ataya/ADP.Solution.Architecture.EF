using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Categories.Queries.GetCategoriesListWithTasks
{
    public class GetCategoriesListWithTasksQuery : IRequest<List<CategoryTasksListVm>>
    {
    }
}
