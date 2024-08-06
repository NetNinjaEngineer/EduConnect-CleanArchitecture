namespace EduConnect.Application.DTOs.Course;
public record CourseDto
{
    public Guid Id { get; set; }
    public string? CourseName { get; set; }
    public int Duration { get; set; }
    public Guid? TopicId { get; set; }
    public string? TopicName { get; set; }
}
