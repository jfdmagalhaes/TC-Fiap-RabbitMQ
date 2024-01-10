using MassTransit;
using NotificationAPI.Domain.Aggregates;
using NotificationAPI.Domain.Interfaces;

namespace NotificationAPI.Worker.Consumer;
public class NotificationReader : IConsumer<Notification>
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationReader(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository ?? 
            throw new ArgumentNullException(nameof(notificationRepository));
    }

    public async Task Consume(ConsumeContext<Notification> context)
    {
        try
        {
            var notification = new Notification
            {
                Message = context.Message.Message,
                CreationDate = context.Message.CreationDate
            };

            await _notificationRepository.AddAndCommitNotification(notification);

            Console.WriteLine($"{context.Message.Message} message was saved successfully");

        }
        catch (Exception ex) 
        { 
            throw new Exception(ex.Message); 
        }
    }
}