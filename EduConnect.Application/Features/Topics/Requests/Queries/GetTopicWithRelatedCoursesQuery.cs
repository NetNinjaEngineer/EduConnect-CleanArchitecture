using EduConnect.Application.Abstractions.Interfaces.Persistence.Models;
using MediatR;

namespace EduConnect.Application.Features.Topics.Requests.Queries;
public sealed class GetTopicWithRelatedCoursesQuery : IRequest<IReadOnlyList<TopicWithRelatedCourses>>
{
    public Guid TopicId { get; set; }
}
