using Microsoft.AspNetCore.Mvc;
using Moq;
using NotificationAPI.Domain.Interfaces;
using NotificationAPI.WebApi.Controllers;

namespace NotificationAPI.UnitTests.WebApi;

[TestFixture]
public class NotificationControllerTests
{
    private NotificationController _notificationController;
    private Mock<INotificationProducer> _producer = new();

    public NotificationControllerTests()
    {
        _notificationController = new NotificationController(_producer.Object);
    }

    [Test]
    public async Task SendMessage_ShouldExecute_Successfulley()
    {
        //arr
        var notification = UnitTestTools.CreateNotification();

        //act
        var result = await _notificationController.SendMessage(notification);

        //assert
        Assert.IsInstanceOf<OkResult>(result);

    }
}
