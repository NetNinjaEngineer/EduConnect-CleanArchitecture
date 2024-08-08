using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.Exceptions;
using EduConnect.Application.Features.Topics.Requests.Commands;
using EduConnect.Application.Helpers;
using EduConnect.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.Features.Topics.Handlers.Commands;
internal sealed class DeleteTopicCommandHandler(
    IUnitOfWork unitOfWork,
    IStringLocalizer<DeleteTopicCommandHandler> localizer) : IRequestHandler<DeleteTopicCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var existingTopic = await unitOfWork.Repository<Topic>()!.GetEntityAsync(request.TopicId)
            ?? throw new NotFoundException(localizer[SharedResourcesKeys.TopicNotFoundMessage, request.TopicId]);

        unitOfWork.Repository<Topic>()!.Delete(existingTopic);
        await unitOfWork.SaveAsync();

        return Unit.Value;

    }
}
