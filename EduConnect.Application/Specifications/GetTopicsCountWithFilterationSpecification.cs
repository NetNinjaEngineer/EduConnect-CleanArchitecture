using EduConnect.Application.Helpers;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Specifications;
public sealed class GetTopicsCountWithFilterationSpecification(TopicRequestParams topicRequestParams)
    : BaseSpecification<Topic>(x =>
        (string.IsNullOrEmpty(topicRequestParams.SearchTerm)) || x.TopicName!.ToLower().Contains(topicRequestParams.SearchTerm));
