namespace LAB1.Models.Domain
{
    public class ForumTopic
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
