using AutoMapper;
using EduConnect.Application.Abstractions;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Application.Features.Topics.Requests.Commands;
using EduConnect.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EduConnect.Application.Features.Topics.Handlers.Commands
{
    public sealed class CreateTopicCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IValidator<TopicForCreationDto> validator
        ) : IRequestHandler<CreateTopicCommand, Result<TopicDto>>
    {
        public async Task<Result<TopicDto>> Handle(
            CreateTopicCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request.Topic, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var mappedTopic = mapper.Map<Topic>(request.Topic);
            unitOfWork.Repository<Topic>()!.Create(mappedTopic);

            await unitOfWork.SaveAsync();

            return Result<TopicDto>.Success(mapper.Map<TopicDto>(mappedTopic));
        }
    }
}
