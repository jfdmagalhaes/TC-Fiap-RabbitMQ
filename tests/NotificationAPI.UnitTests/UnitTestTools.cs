using AutoFixture;
using MassTransit;
using NotificationAPI.Domain.Aggregates;

namespace NotificationAPI.UnitTests;

public class UnitTestTools
{
    internal static IList<Notification> CreateNotifications()
        => new Fixture().Create<IList<Notification>>();

    internal static Notification CreateNotification()
    {
        return new Fixture().Create<Notification>();
    }

}