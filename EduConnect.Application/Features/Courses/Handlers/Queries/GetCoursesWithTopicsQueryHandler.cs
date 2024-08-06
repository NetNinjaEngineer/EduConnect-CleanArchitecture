using AutoMapper;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Course;
using EduConnect.Application.Features.Courses.Requests.Queries;
using EduConnect.Application.Helpers;
using EduConnect.Application.Specifications;
using EduConnect.Domain.Entities;
using MediatR;

namespace EduConnect.Application.Features.Courses.Handlers.Queries;
public sealed class GetCoursesWithTopicsQueryHandler : IRequestHandler<GetCoursesWithTopicsQuery, Pagination<CourseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCoursesWithTopicsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Pagination<CourseDto>> Handle(GetCoursesWithTopicsQuery request, CancellationToken cancellationToken)
    {
        var specification = new GetCoursesWithTopicsSpecification(request.Parameters);
        var courses = await _unitOfWork.Repository<Course>()!.GetAllWithSpecificationAsync(specification);
        var mappedCourses = _mapper.Map<IReadOnlyList<CourseDto>>(courses);
        var countSpecification = new CountCoursesWithFilterationSpecification(request.Parameters);
        return new Pagination<CourseDto>(
            request.Parameters.PageNumber,
            request.Parameters.PageSize,
            await _unitOfWork.Repository<Course>()!.CountWithSpecificationAsync(countSpecification),
            mappedCourses);
    }
}
