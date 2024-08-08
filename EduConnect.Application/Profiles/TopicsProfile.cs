using AutoMapper;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Profiles;
public class TopicsProfile : Profile
{
    public TopicsProfile()
    {
        CreateMap<Topic, TopicDto>()
            .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.GetLocalized()[0]));
        CreateMap<TopicForCreationDto, Topic>();
        CreateMap<TopicForUpdateDto, Topic>();
    }
}
