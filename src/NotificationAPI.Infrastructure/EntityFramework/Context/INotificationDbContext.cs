using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NotificationAPI.Domain.Aggregates;
using System.Data;

namespace NotificationAPI.Infrastructure.EntityFramework.Context;
public interface INotificationDbContext
{
    IDbConnection Connection { get; }
    DbSet<Notification> Notifications { get; }

    Task<bool> CommitAsync();
    IDbContextTransaction GetCurrentTransaction();
}