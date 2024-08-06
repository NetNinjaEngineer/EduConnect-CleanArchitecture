namespace EduConnect.Application.DTOs.Topic
{
    public sealed record TopicDto
    {
        public Guid Id { get; set; }
        public string? TopicName { get; set; }
    }
}
