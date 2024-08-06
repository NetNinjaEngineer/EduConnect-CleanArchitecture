using EduConnect.Application.Abstractions;
using EduConnect.Application.DTOs.Topic;
using MediatR;

namespace EduConnect.Application.Features.Topics.Commands.CreateTopic
{
    public sealed class CreateTopicCommand : IRequest<Result<TopicDto>>
    {
        public TopicForCreationDto Topic { get; set; }
    }
}
