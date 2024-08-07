using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.Abstractions.Interfaces.Persistence.Models;
using EduConnect.Application.Features.Topics.Requests.Queries;
using MediatR;

namespace EduConnect.Application.Features.Topics.Handlers.Queries;
public sealed class GetTopicWithRelatedCoursesQueryHandler
    : IRequestHandler<GetTopicWithRelatedCoursesQuery, IReadOnlyList<TopicWithRelatedCourses>>
{
    private readonly ITopicRepository _topicRepository;

    public GetTopicWithRelatedCoursesQueryHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<IReadOnlyList<TopicWithRelatedCourses>> Handle(
        GetTopicWithRelatedCoursesQuery request,
        CancellationToken cancellationToken)
    {
        return await _topicRepository.GetTopicWithRelatedCourses(request.TopicId);
    }
}
