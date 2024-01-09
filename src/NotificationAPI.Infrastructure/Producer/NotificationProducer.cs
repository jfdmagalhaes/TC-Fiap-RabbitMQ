using MassTransit;
using NotificationAPI.Domain.Aggregates;
using NotificationAPI.Domain.Helpers;
using NotificationAPI.Domain.Interfaces;

namespace NotificationAPI.Infrastructure.Producer;
public class NotificationProducer : INotificationProducer
{
    private readonly IBus _bus;
    private readonly AppSettings _appSettings;

    public NotificationProducer(IBus bus, AppSettings appSettings)
    {
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
    }

    public async Task SendMessageAsync(Notification notification)
    {
        Uri uri = new($"queue:{_appSettings.MassTransit.NomeFila}");
        var endPoint = await _bus.GetSendEndpoint(uri);

        await endPoint.Send(notification, CancellationToken.None);
    }
}