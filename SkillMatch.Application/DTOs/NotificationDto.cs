namespace SkillMatch.Application.DTOs
{
	public class NotificationDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Message { get; set; }
		public DateTime SentAt { get; set; }
		public bool IsRead { get; set; }
	}

	public class CreateNotificationDto
	{
		public int UserId { get; set; }
		public string Message { get; set; }
	}

	public class UpdateNotificationDto
	{
		public bool IsRead { get; set; }
	}
}
