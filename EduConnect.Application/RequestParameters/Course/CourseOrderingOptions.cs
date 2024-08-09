using System.Text.Json.Serialization;

namespace EduConnect.Application.RequestParameters.Course;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CourseOrderingOptions
{
    DurationAsc = 0,
    DurationDesc = 1,
    CourseNameAsc = 2,
    CourseNameDesc = 4,
    NameAscDurationDesc = CourseNameAsc | DurationDesc,
    NameDescDurationAsc = CourseNameDesc | DurationAsc
}
