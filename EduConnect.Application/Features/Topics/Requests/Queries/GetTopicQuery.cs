using EduConnect.Application.DTOs.Topic;
using MediatR;

namespace EduConnect.Application.Features.Topics.Requests.Queries;
public sealed class GetTopicQuery(Guid id) : IRequest<TopicDto>
{
    public Guid Id { get; } = id;
}
