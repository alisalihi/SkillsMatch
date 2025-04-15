namespace SkillMatch.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public string Type { get; set; } // "JobMatch", "Application", "System"
        public string? RelatedEntityType { get; set; }
        public int? RelatedEntityId { get; set; }
    }
}