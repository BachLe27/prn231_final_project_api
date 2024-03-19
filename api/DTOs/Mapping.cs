using AutoMapper;

namespace api.DTOs
{
    public class Mapping
    {
        public static Mapper InitMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                /*cfg.CreateMap<Project, ProjectDTO>()
                .ForMember(d => d.projectId, act => act.MapFrom(src => src.ProjectId))
                .ForMember(d => d.projectName, act => act.MapFrom(src => src.ProjectName))
                .ForMember(d => d.startDate, act => act.MapFrom(src => src.StartDate))
                .ForMember(d => d.endDate, act => act.MapFrom(src => src.EndDate))
                .ForMember(d => d.budget, act => act.MapFrom(src => src.Budget))
                .ForMember(d => d.numberOfEmployee, act => act.MapFrom(src => src.EmployeeProjects.Select(x => x.EmployeeId).Count()))
                .ReverseMap();*/

                

            });
            var mapper = new Mapper(config);
            return mapper;
        }

    }
}
