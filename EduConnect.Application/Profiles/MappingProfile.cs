using AutoMapper;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Domain;

namespace EduConnect.Application.Profiles
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Topic, TopicDto>();
            CreateMap<TopicForCreationDto, Topic>();
        }
    }
}
