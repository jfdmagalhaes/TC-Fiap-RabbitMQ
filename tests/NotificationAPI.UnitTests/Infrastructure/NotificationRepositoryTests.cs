using MockQueryable.Moq;
using Moq;
using NotificationAPI.Domain.Aggregates;
using NotificationAPI.Infrastructure.EntityFramework.Context;
using NotificationAPI.Infrastructure.Persistence;

namespace NotificationAPI.UnitTests.Infrastructure;

[TestFixture]
public class NotificationRepositoryTests
{
    private NotificationRepository _repository;
    private Mock<INotificationDbContext> _context = new();
    private readonly List<Notification> notifications = new();

    public NotificationRepositoryTests()
    {
        notifications.AddRange(UnitTestTools.CreateNotifications());
        var notificationsMock = notifications.AsQueryable().BuildMockDbSet();

        _context.Setup(x => x.Notifications).Returns(notificationsMock.Object);
        _repository = new NotificationRepository(_context.Object);
    }

    [Test]
    public void AddAndCommitNotification_ExecuteSuccessfully()
    {
        var notification = new Notification();

        Assert.DoesNotThrowAsync(async () => await _repository.AddAndCommitNotification(notification));
    }

    [Test]
    public void Dispose()
    => Assert.DoesNotThrow(() => _repository.Dispose());
}