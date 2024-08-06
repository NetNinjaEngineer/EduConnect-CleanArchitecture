using EduConnect.Application.DTOs.Course;
using EduConnect.Application.Helpers;
using MediatR;

namespace EduConnect.Application.Features.Courses.Requests.Queries;
public sealed class GetCoursesWithTopicsQuery : IRequest<Pagination<CourseDto>>
{
    public CourseRequestParameters Parameters { get; set; }
}
