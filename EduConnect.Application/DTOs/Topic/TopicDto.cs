using EduConnect.Application.DTOs.Common;

namespace EduConnect.Application.DTOs.Topic
{
    public sealed record TopicDto : BaseDto
    {
        public string? TopicName { get; set; }
    }
}
