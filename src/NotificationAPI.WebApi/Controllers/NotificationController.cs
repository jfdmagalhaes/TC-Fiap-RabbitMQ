using Microsoft.AspNetCore.Mvc;
using NotificationAPI.Domain.Aggregates;
using NotificationAPI.Domain.Interfaces;

namespace NotificationAPI.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private INotificationProducer _producer;

    public NotificationController(INotificationProducer producer)
    {
        _producer = producer ?? throw new ArgumentNullException(nameof(producer));
    }

    [HttpPost("SendMessage")]

    public async Task<IActionResult> SendMessage(Notification notification)
    {
        await _producer.SendMessageAsync(notification);
        return Ok();
    }
}
