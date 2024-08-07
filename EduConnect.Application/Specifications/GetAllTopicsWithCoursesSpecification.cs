using EduConnect.Application.Helpers;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Specifications;
public class GetAllTopicsWithCoursesSpecification : BaseSpecification<Topic>
{
    public GetAllTopicsWithCoursesSpecification()
    {
        Includes.Add(x => x.Courses);
    }

    public GetAllTopicsWithCoursesSpecification(TopicRequestParams topicRequestParams) : base
        (topic =>
            (string.IsNullOrEmpty(topicRequestParams.SearchTerm)) || topic.TopicName!.ToLower().Contains(topicRequestParams.SearchTerm)
        )
    {
        Includes.Add(x => x.Courses);

        if (!string.IsNullOrEmpty(topicRequestParams.Sort))
        {
            switch (topicRequestParams.Sort)
            {
                case "NameAsc":
                    AddOrderBy(x => x.TopicName!);
                    break;

                case "NameDesc":
                    AddOrderByDescending(x => x.TopicName!);
                    break;

                default:
                    AddOrderBy(x => x.TopicName!);
                    break;
            }
        }

        ApplyPagination((topicRequestParams.PageNumber - 1) * topicRequestParams.PageSize, topicRequestParams.PageSize);
    }
}
