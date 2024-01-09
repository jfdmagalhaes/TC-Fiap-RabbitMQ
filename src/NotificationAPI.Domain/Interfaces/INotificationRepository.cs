using NotificationAPI.Domain.Aggregates;

namespace NotificationAPI.Domain.Interfaces;
public interface INotificationRepository : IDisposable
{
    Task AddAndCommitNotification(Notification notification);
}