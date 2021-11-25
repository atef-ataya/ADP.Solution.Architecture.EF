using ADP.Solution.Application.Contracts.Persistence;
using ADP.Solution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP.Solution.Persistence.Respositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ADPDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithTasks()
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Tasks).ToListAsync();
         
            return allCategories;
        }
    }
}
