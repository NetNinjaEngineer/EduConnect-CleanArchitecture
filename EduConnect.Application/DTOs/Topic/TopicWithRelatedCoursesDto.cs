using EduConnect.Application.DTOs.Common;
using EduConnect.Application.DTOs.Course;

namespace EduConnect.Application.Abstractions.Interfaces.Persistence.Models;
public record TopicWithRelatedCoursesDto : BaseDto
{
    public string? TopicName { get; set; }
    public IEnumerable<CourseForListDto> Courses { get; set; } = [];
}
