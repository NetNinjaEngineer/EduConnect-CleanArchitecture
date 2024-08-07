using EduConnect.Application.Helpers;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Specifications;
public sealed class GetTopicsCountWithFilterationSpecification : BaseSpecification<Topic>
{
    public GetTopicsCountWithFilterationSpecification(TopicRequestParams topicRequestParams)
        : base(x =>
            (string.IsNullOrEmpty(topicRequestParams.SearchTerm) || x.TopicName!.ToLower().Contains(topicRequestParams.SearchTerm))
        )
    {

    }
}