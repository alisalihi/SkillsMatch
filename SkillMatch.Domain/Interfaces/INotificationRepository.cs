using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<IReadOnlyList<Notification>> GetByUserIdAsync(int userId);
        Task<IReadOnlyList<Notification>> GetUnreadByUserIdAsync(int userId);
        Task<int> GetUnreadCountByUserIdAsync(int userId);
        Task MarkAsReadAsync(int notificationId);
        Task MarkAllAsReadForUserAsync(int userId);
    }
}