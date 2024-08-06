using AutoMapper;

namespace EduConnect.Application.Mapping.Topics
{
    public partial class TopicsProfile : Profile
    {
        public TopicsProfile()
        {
            GetTopicsListMapping();
            CreateTopicMapping();
        }
    }
}
