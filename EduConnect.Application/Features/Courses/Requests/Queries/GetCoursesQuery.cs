using EduConnect.Domain.Entities;
using MediatR;

namespace EduConnect.Application.Features.Courses.Requests.Queries;
public sealed class GetCoursesQuery : IRequest<IReadOnlyList<Course>>
{
}
