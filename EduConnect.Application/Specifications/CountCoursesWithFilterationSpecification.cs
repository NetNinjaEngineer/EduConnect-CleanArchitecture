using EduConnect.Application.Helpers;
using EduConnect.Domain.Entities;

namespace EduConnect.Application.Specifications;
public sealed class CountCoursesWithFilterationSpecification : BaseSpecification<Course>
{
    public CountCoursesWithFilterationSpecification(CourseRequestParameters parameters) :
         base(c =>
            (string.IsNullOrEmpty(parameters.SearchTerm)) ||
            c.CourseName!.ToLower()!.Contains(parameters.SearchTerm) ||
            c.Topic!.TopicName!.ToLower().Contains(parameters.SearchTerm)
            && c.TopicId!.ToString() == parameters.TopicId
        )
    {
    }
}
