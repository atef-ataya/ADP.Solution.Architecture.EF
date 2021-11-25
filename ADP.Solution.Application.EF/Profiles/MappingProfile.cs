using ADP.Solution.Application.Features.Categories.Commands.CreateCategory;
using ADP.Solution.Application.Features.Categories.Queries.GetCategoriesList;
using ADP.Solution.Application.Features.Categories.Queries.GetCategoriesListWithTasks;
using ADP.Solution.Application.Features.Tasks.Commands.CreateTask;
using ADP.Solution.Application.Features.Tasks.Commands.UpdateTask;
using ADP.Solution.Application.Features.Tasks.Queries.GetTaskDetails;
using ADP.Solution.Application.Features.Tasks.Queries.GetTasksExport;
using ADP.Solution.Application.Features.Tasks.Queries.GetTasksList;
using ADP.Solution.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdaaTask, TaskListVm>().ReverseMap();
            CreateMap<AdaaTask, CreateTaskCommand>().ReverseMap();
            CreateMap<AdaaTask, UpdateTaskCommand>().ReverseMap();
            CreateMap<AdaaTask, TaskDetailVm>().ReverseMap();
            CreateMap<AdaaTask, CategoryTasksDto>().ReverseMap();
            CreateMap<AdaaTask, TaskExportDto>().ReverseMap();

            CreateMap<AdaaTask, TaskDetailVm>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryTasksListVm>();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
