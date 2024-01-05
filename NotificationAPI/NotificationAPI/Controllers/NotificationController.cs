using Microsoft.AspNetCore.Mvc;
using NotificationAPI.Domain.Aggregates;
using NotificationAPI.Domain.Interfaces;
using System.Net.Mime;

namespace NotificationAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private ILogger<NotificationController> _logger;
    private INotificationProducer _producer;

    public NotificationController(ILogger<NotificationController> logger, INotificationProducer producer)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _producer = producer ?? throw new ArgumentNullException(nameof(producer));
    }

    [HttpPost("SendMessage")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult SendMessage(Notification notification)
    {
        return Ok();
    }
}
