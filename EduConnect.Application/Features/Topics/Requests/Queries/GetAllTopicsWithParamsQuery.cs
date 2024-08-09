using EduConnect.Application.Abstractions;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Application.Helpers;
using EduConnect.Application.RequestParameters.Topic;
using MediatR;

namespace EduConnect.Application.Features.Topics.Requests.Queries;
public sealed class GetAllTopicsWithParamsQuery : IRequest<Result<Pagination<TopicDto>>>
{
    public TopicRequestParams TopicRequestParams { get; set; }
}
