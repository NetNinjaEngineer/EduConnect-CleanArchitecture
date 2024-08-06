using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.Features.Courses.Requests.Queries;
using EduConnect.Domain.Entities;
using MediatR;

namespace EduConnect.Application.Features.Courses.Handlers.Queries;
public sealed class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IReadOnlyList<Course>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCoursesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Course>()!.GetAllAsync();
    }
}
