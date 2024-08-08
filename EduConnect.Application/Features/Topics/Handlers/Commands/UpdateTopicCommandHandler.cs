using AutoMapper;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.Exceptions;
using EduConnect.Application.Features.Topics.Requests.Commands;
using EduConnect.Application.Resources;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.DTOs.Topic.Handlers.Commands;
public sealed class UpdateTopicCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IStringLocalizer<SharedResources> localizer,
    IValidator<TopicForUpdateDto> validator
    ) : IRequestHandler<UpdateTopicCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request.UpdatedTopic, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingTopic = await unitOfWork.Repository<Domain.Entities.Topic>()!.GetEntityAsync(request.TopicId)
              ?? throw new NotFoundException(localizer[SharedResourcesKeys.TopicNotFoundMessage, request.TopicId]);

        mapper.Map(request.UpdatedTopic, existingTopic);

        unitOfWork.Repository<Domain.Entities.Topic>()!.Update(existingTopic);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}