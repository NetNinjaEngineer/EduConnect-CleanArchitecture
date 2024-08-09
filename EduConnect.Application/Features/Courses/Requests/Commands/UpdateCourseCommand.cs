using EduConnect.Application.DTOs.Course;
using MediatR;

namespace EduConnect.Application.Features.Courses.Requests.Commands;
public sealed class UpdateCourseCommand(Guid id, CourseForUpdateDto course) : IRequest<Unit>
{
    public Guid Id { get; } = id;
    public CourseForUpdateDto Course { get; } = course;
}
