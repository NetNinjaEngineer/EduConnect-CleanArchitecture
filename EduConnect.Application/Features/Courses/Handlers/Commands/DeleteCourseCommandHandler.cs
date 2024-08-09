using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.Exceptions;
using EduConnect.Application.Features.Courses.Requests.Commands;
using EduConnect.Application.Features.Topics.Requests.Commands;
using EduConnect.Application.Helpers;
using EduConnect.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.Features.Courses.Handlers.Commands;
public sealed class DeleteCourseCommandHandler(
    IUnitOfWork unitOfWork,
    IStringLocalizer<DeleteTopicCommand> localizer) : IRequestHandler<DeleteCourseCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var existingCourse = await unitOfWork.Repository<Course>()!.GetEntityAsync(request.Id)
        ?? throw new NotFoundException(localizer[SharedResourcesKeys.CourseNotFoundMessage, request.Id]);

        unitOfWork.Repository<Course>()!.Delete(existingCourse);
        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
