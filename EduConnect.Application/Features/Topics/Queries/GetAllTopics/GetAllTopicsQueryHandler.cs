using AutoMapper;
using EduConnect.Application.Abstractions;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Domain;
using MediatR;

namespace EduConnect.Application.Features.Topics.Queries.GetAllTopics
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
