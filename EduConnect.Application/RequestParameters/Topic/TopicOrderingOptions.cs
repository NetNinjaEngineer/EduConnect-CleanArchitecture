using System.Text.Json.Serialization;

namespace EduConnect.Application.RequestParameters.Topic;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TopicOrderingOptions
{
    NameAsc,
    NameDesc
}
