using NotificationAPI.Domain.Aggregates;

namespace NotificationAPI.Domain.Interfaces;
public interface INotificationProducer
{
    Task SendMessageAsync(Notification notification);
}