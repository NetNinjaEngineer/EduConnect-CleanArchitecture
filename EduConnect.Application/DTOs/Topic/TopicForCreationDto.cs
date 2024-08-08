namespace EduConnect.Application.DTOs.Topic
{
    public sealed record TopicForCreationDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? TopicName { get; set; }
        public string? TopicNameAr { get; set; }
    }
}
