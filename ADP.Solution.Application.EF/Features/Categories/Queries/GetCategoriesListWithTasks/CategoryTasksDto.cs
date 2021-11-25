using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Categories.Queries.GetCategoriesListWithTasks
{
    public class CategoryTasksDto
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}
