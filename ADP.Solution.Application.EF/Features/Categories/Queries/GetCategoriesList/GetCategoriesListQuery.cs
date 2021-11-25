using ADP.Solution.Application.Contracts.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>, ICacheableMediatrQuery
    {
        public bool BypassCache { get; set; }
        public string CacheKey => $"CategoryList";
        public TimeSpan? SlidingExpiration { get; set; }
    }
}
