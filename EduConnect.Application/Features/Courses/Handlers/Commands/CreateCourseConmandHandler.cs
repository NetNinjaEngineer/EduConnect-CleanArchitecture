using AutoMapper;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Course;
using EduConnect.Application.Features.Courses.Requests.Commands;
using EduConnect.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EduConnect.Application.Features.Courses.Handlers.Commands;
public sealed class CreateCourseConmandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IValidator<CourseForCreateDto> validator
    ) : IRequestHandler<CreateCourseCommand, CourseForListDto>
{
    public async Task<CourseForListDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request.Course, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var mappedCourse = mapper.Map<Course>(request.Course);
        unitOfWork.Repository<Course>()!.Create(mappedCourse);

        await unitOfWork.SaveAsync();
        return mapper.Map<Course, CourseForListDto>(mappedCourse);
    }
}
