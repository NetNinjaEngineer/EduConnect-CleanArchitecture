using EduConnect.Application.DTOs.Course;
using MediatR;

namespace EduConnect.Application.Features.Courses.Requests.Queries;

public class GetCoursesListQuery : IRequest<IReadOnlyList<CourseForListDto>>
{
    
}