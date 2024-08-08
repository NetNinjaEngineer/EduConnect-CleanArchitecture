using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.Abstractions.Interfaces.Persistence.Models;
using EduConnect.Application.Exceptions;
using EduConnect.Application.Features.Topics.Requests.Queries;
using EduConnect.Application.Localization;
using MediatR;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.Features.Topics.Handlers.Queries;
public sealed class GetTopicWithRelatedCoursesQueryHandler
    : IRequestHandler<GetTopicWithRelatedCoursesQuery, TopicWithRelatedCoursesDto>
{
    private readonly ITopicRepository _topicRepository;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public GetTopicWithRelatedCoursesQueryHandler(
        ITopicRepository topicRepository, IStringLocalizer<SharedResources> localizer)
    {
        _topicRepository = topicRepository;
        _localizer = localizer;
    }

    public async Task<TopicWithRelatedCoursesDto> Handle(
        GetTopicWithRelatedCoursesQuery request,
        CancellationToken cancellationToken)
    {
        return await _topicRepository.GetTopicWithRelatedCourses(request.TopicId)
            ?? throw new NotFoundException(_localizer[SharedResourcesKeys.TopicNotFoundMessage, request.TopicId]);
    }
}
