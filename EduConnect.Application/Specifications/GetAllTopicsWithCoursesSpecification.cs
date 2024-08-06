using EduConnect.Application.Helpers;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Specifications;
public class GetAllTopicsWithCoursesSpecification : BaseSpecification<Topic>
{
    public GetAllTopicsWithCoursesSpecification(TopicRequestParams topicRequestParams) : base
        (topic =>
            (string.IsNullOrEmpty(topicRequestParams.SearchTerm)) || topic.TopicName!.ToLower().Contains(topicRequestParams.SearchTerm)
        )
    {
        Includes.Add(x => x.Courses);
        ApplyPagination((topicRequestParams.PageNumber - 1) * topicRequestParams.PageSize, topicRequestParams.PageSize);
    }
}
