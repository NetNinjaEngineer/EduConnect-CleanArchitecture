using AutoMapper;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Course;
using EduConnect.Application.Exceptions;
using EduConnect.Application.Features.Courses.Requests.Commands;
using EduConnect.Application.Helpers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.Features.Courses.Handlers.Commands;
public sealed class UpdateCourseCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IValidator<CourseForUpdateDto> validator,
    IStringLocalizer<UpdateCourseCommandHandler> localizer
    ) : IRequestHandler<UpdateCourseCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request.Course, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCourse = await unitOfWork.Repository<Domain.Entities.Course>()!.GetEntityAsync(request.Id)
              ?? throw new NotFoundException(localizer[SharedResourcesKeys.CourseNotFoundMessage, request.Id]);

        mapper.Map(request.Course, existingCourse);

        unitOfWork.Repository<Domain.Entities.Course>()!.Update(existingCourse);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
