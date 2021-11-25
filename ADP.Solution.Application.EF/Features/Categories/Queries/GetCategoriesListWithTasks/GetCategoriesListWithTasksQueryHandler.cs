using ADP.Solution.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.Solution.Application.Features.Categories.Queries.GetCategoriesListWithTasks
{
    public class GetCategoriesListWithTasksQueryHandler : IRequestHandler<GetCategoriesListWithTasksQuery, List<CategoryTasksListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithTasksQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryTasksListVm>> Handle(GetCategoriesListWithTasksQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithTasks();
            return _mapper.Map<List<CategoryTasksListVm>>(list);
        }
    }
}
