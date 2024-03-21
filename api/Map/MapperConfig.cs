using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.Map
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Contest, ContestDTO>().ReverseMap();
            CreateMap<User, StudentDTO>().ReverseMap();
            CreateMap<Submission, SubmissionDTO>().ReverseMap();                
        }
    }
}
