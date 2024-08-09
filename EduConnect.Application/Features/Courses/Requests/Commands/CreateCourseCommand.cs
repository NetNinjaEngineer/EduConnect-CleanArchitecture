using EduConnect.Application.DTOs.Course;
using MediatR;

namespace EduConnect.Application.Features.Courses.Requests.Commands;
public sealed class CreateCourseCommand : IRequest<CourseForListDto>
{
    public CourseForCreateDto Course { get; set; }
}
