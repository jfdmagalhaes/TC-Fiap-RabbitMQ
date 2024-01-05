using MassTransit;
using NotificationAPI.Domain.Aggregates;

namespace NotificationAPI.Worker.Consumer;
public class NotificationReader : IConsumer<Notification>
{
    public Task Consume(ConsumeContext<Notification> context)
    {
        Console.WriteLine(context.Message.Message);
        return Task.CompletedTask;
    }
}