using EduConnect.Application.DTOs.Course;
using EduConnect.Application.DTOs.Topic;

namespace EduConnect.Application.Abstractions.Interfaces.Persistence.Models;
public class TopicWithRelatedCourses
{
    public TopicDto? Topic { get; set; }
    public IEnumerable<CourseForListDto> Courses { get; set; } = [];
}
