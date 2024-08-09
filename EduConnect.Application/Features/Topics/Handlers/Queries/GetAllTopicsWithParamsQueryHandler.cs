using AutoMapper;
using EduConnect.Application.Abstractions;
using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Application.DTOs.Topic;
using EduConnect.Application.Features.Topics.Requests.Queries;
using EduConnect.Application.Helpers;
using EduConnect.Application.Specifications;
using EduConnect.Domain.Entities;
using MediatR;

namespace EduConnect.Application.Features.Topics.Handlers.Queries;
public sealed class GetAllTopicsWithParamsQueryHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllTopicsWithParamsQuery, Result<Pagination<TopicDto>>>
{

    public async Task<Result<Pagination<TopicDto>>> Handle(
        GetAllTopicsWithParamsQuery request,
        CancellationToken cancellationToken)
    {
        var specification = new GetAllTopicsWithCoursesSpecification(request.TopicRequestParams);

        var topics = await unitOfWork.Repository<Topic>()!.GetAllWithSpecificationAsync(specification);

        var mappedTopics = mapper.Map<IReadOnlyList<TopicDto>>(topics);
        var specificationCountWithFilteration = new GetTopicsCountWithFilterationSpecification(request.TopicRequestParams);
        var count = await unitOfWork.Repository<Topic>()!.CountWithSpecificationAsync(specificationCountWithFilteration);

        return Result<Pagination<TopicDto>>.Success(Pagination<TopicDto>.ToPaginatedResult(
            request.TopicRequestParams.PageNumber,
            request.TopicRequestParams.PageSize,
            count,
            mappedTopics));
    }
}
