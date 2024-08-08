using AutoMapper;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Application.Exceptions;
using EduConnect.Application.Features.Topics.Requests.Queries;
using EduConnect.Application.Resources;
using EduConnect.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.Features.Topics.Handlers.Queries;
public sealed class GetTopicQueryHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IStringLocalizer<SharedResources> localizer
    ) : IRequestHandler<GetTopicQuery, TopicDto>
{
    public async Task<TopicDto> Handle(GetTopicQuery request, CancellationToken cancellationToken)
    {
        var topic = await unitOfWork.Repository<Topic>()!.GetEntityAsync(request.Id)
            ?? throw new NotFoundException(localizer[SharedResourcesKeys.TopicNotFoundMessage, request.Id]);
        var mappedTopic = mapper.Map<Topic, TopicDto>(topic);
        return mappedTopic;
    }
}
