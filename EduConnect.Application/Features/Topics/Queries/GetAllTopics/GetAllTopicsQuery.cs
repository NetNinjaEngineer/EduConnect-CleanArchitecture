using EduConnect.Application.Abstractions;
using EduConnect.Application.DTOs.Topic;
using MediatR;

namespace EduConnect.Application.Features.Topics.Queries.GetAllTopics
{
    public sealed class GetAllTopicsQuery : IRequest<Result<IReadOnlyList<TopicDto>>>;
}
