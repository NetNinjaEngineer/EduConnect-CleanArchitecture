using EduConnect.Application.Abstractions;
using EduConnect.Application.DTOs.Topic;
using MediatR;

namespace EduConnect.Application.Features.Topics.Requests.Queries
{
    public sealed class GetAllTopicsQuery : IRequest<Result<IReadOnlyList<TopicDto>>>;
}
