using AutoMapper;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Course;
using EduConnect.Application.Features.Courses.Requests.Queries;
using EduConnect.Domain.Entities;
using MediatR;

namespace EduConnect.Application.Features.Courses.Handlers.Queries;

public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, IReadOnlyList<CourseForListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCoursesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CourseForListDto>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.Repository<Course>().GetAllAsync();
        var mappedCourses = _mapper.Map<IReadOnlyList<Course>, IReadOnlyList<CourseForListDto>>(courses);
        return mappedCourses;
    }
}