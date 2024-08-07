using AutoMapper;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Topic.Validators;
using EduConnect.Application.Exceptions;
using EduConnect.Application.Features.Topics.Requests.Commands;
using FluentValidation;
using MediatR;

namespace EduConnect.Application.DTOs.Topic.Handlers.Commands;
public sealed class UpdateTopicCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateTopicCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTopicCommandValidator();
        var validationResult = await validator.ValidateAsync(request.UpdatedTopic, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingTopic = await unitOfWork.Repository<Domain.Entities.Topic>()!.GetEntityAsync(request.TopicId)
              ?? throw new NotFoundException($"The topic with id: '{request.TopicId}' was not found.");

        mapper.Map(request.UpdatedTopic, existingTopic);

        unitOfWork.Repository<Domain.Entities.Topic>()!.Update(existingTopic);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}