using EduConnect.Application.DTOs.Topic;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Mapping.Topics
{
    public partial class TopicsProfile
    {
        public void CreateTopicMapping()
        {
            CreateMap<TopicForCreationDto, Topic>();
        }
    }
}
