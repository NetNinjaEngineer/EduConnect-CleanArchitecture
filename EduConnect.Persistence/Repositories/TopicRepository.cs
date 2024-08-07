using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.Abstractions.Interfaces.Persistence.Models;
using EduConnect.Application.DTOs.Course;
using EduConnect.Application.Specifications;
using EduConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.Persistence.Repositories;
public sealed class TopicRepository(ApplicationDbContext context)
    : GenericRepository<Topic>(context), ITopicRepository
{
    public async Task<IReadOnlyList<TopicWithRelatedCourses>> GetTopicWithRelatedCourses(Guid topicId)
    {
        var specification = new GetAllTopicsWithCoursesSpecification();
        var query = await _context.Topics
            .Where(x => x.Id == topicId)
            .Select(x => new TopicWithRelatedCourses
            {
                Topic = new() { Id = x.Id, TopicName = x.TopicName },
                Courses = x.Courses.Select(c => new CourseForListDto
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    Duration = c.Duration
                })
            }).ToListAsync();

        return query;
    }
}
