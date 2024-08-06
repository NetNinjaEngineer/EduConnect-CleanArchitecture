using EduConnect.Application.Helpers;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Specifications;
internal class GetCoursesWithTopicsSpecification : BaseSpecification<Course>
{
    public GetCoursesWithTopicsSpecification(CourseRequestParameters parameters) :
        base(c =>
            (string.IsNullOrEmpty(parameters.SearchTerm)) ||
            c.CourseName!.ToLower()!.Contains(parameters.SearchTerm) ||
            c.Topic!.TopicName!.ToLower().Contains(parameters.SearchTerm)
            && c.TopicId!.ToString() == parameters.TopicId
        )
    {
        Includes.Add(x => x.Topic!);

        if (!string.IsNullOrEmpty(parameters.Sort))
        {
            switch (parameters.Sort)
            {
                case "DurationAsc":
                    AddOrderBy(c => c.Duration);
                    break;

                case "DurationDesc":
                    AddOrderByDescending(c => c.Duration);
                    break;

                default:
                    break;
            }
        }

        ApplyPagination((parameters.PageNumber - 1) * parameters.PageSize, parameters.PageSize);
    }
}
