using ADP.Solution.Application.Contracts.Persistence;
using ADP.Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP.Solution.Persistence.Respositories
{
    public class TaskRepository : BaseRepository<AdaaTask>, ITasksRepository
    {
        public TaskRepository(ADPDbContext dbContext) : base(dbContext)
        {
        }
        public Task<bool> IsTaskNameAndDateUnique(string name, DateTime taskDate)
        {
            var matches = _dbContext.AdaaTasks.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(taskDate.Date));
            return Task.FromResult(matches);
        }
    }
}
