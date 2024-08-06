using AutoMapper;
using EduConnect.Application.Abstractions;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Application.Features.Topics.Requests.Queries;
using EduConnect.Domain.Entities;
using MediatR;

namespace EduConnect.Application.Features.Topics.Handlers.Queries
{
    public sealed class GetAllTopicsQueryHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<GetAllTopicsQuery, Result<IReadOnlyList<TopicDto>>>
    {
        public async Task<Result<IReadOnlyList<TopicDto>>> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
            => Result<IReadOnlyList<TopicDto>>.Success(
                mapper.Map<IReadOnlyList<TopicDto>>(await unitOfWork.Repository<Topic>()!.GetAllAsync()));
    }
}
