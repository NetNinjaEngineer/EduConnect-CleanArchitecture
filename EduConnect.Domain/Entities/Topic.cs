using EduConnect.Domain.Entities.Common;

namespace EduConnect.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public string? TopicName { get; set; }
        public ICollection<Course> Courses { get; set; } = [];
    }
}
