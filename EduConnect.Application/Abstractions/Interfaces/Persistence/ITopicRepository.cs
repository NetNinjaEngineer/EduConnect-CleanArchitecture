using EduConnect.Application.Abstractions.Interfaces.Persistence.Models;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Abstractions.Interfaces.Persistence;
public interface ITopicRepository : IGenericRepository<Topic>
{
    Task<IReadOnlyList<TopicWithRelatedCourses>> GetTopicWithRelatedCourses(Guid topicId);
}
