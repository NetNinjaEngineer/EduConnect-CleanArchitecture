using AutoMapper;
using EduConnect.Application.DTOs.Course;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Profiles;
internal class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.Topic!.TopicName))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName));
    }
}
