using AutoMapper;
using TaskApi.Data.Dtos;
using TaskApi.Models;

namespace TaskApi.Profiles;

public class WorkTaskProfile : Profile
{
    public WorkTaskProfile()
    {
        CreateMap<WorkTask, ReadWorkTaskDto>()
            .ForMember(t => t.ReadActivitiesDto,
            opt => opt.MapFrom(wt => wt.Activities));
        CreateMap<CreateWorkTaskDto, WorkTask>()
            .ForMember(t => t.Activities,
            opt => opt.MapFrom(wt => wt.WorkActivities));
        CreateMap<UpdateWorkTaskDto, WorkTask>();
        CreateMap<DeleteWorkTaskDto, WorkTask>();
        CreateMap<CreateWorkActivityDto, WorkActivity>();
        CreateMap<WorkActivity, ReadWorkActivityDto>();
        CreateMap<UpdateWorkActivityDto, WorkActivity>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<Category, ReadCategoryDto>();
        CreateMap<CreateWorkTaskCategoryDto, WorkTaskCategory>();
    }
}
