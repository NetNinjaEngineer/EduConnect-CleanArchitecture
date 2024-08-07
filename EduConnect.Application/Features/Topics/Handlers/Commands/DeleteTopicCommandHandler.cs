using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.Exceptions;
using EduConnect.Application.Features.Topics.Requests.Commands;
using EduConnect.Domain.Entities;
using MediatR;

namespace EduConnect.Application.Features.Topics.Handlers.Commands;
internal sealed class DeleteTopicCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteTopicCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var existingTopic = await unitOfWork.Repository<Topic>()!.GetEntityAsync(request.TopicId)
            ?? throw new NotFoundException($"The topic with id: '{request.TopicId}' was not found.");

        unitOfWork.Repository<Topic>()!.Delete(existingTopic);
        await unitOfWork.SaveAsync();

        return Unit.Value;

    }
}
