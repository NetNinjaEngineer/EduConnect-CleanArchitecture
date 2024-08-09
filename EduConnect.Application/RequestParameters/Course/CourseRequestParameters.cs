namespace EduConnect.Application.RequestParameters.Course;

public class CourseRequestParameters : RequestParameters
{
    public string? TopicId { get; set; }
    public CourseOrderingOptions? OrderingOptions { get; set; } = null;
}

