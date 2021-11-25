using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Categories.Queries.GetCategoriesListWithTasks
{
    public class CategoryTasksListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryTasksDto> Tasks { get; set; }
    }
}
