using EduConnect.Domain.Common;

namespace EduConnect.Domain
{
    public class Topic : BaseEntity
    {
        public string? TopicName { get; set; }
        public ICollection<Course> Courses { get; set; } = [];
    }
}
