using EduConnect.Application.DTOs.Common;

namespace EduConnect.Application.DTOs.Course;
public record CourseForListDto : BaseDto
{
    public string? CourseName { get; set; }
    public int Duration { get; set; }
}
