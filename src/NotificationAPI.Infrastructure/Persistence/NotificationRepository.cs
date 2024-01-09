using NotificationAPI.Domain.Aggregates;
using NotificationAPI.Domain.Interfaces;
using NotificationAPI.Infrastructure.EntityFramework.Context;

namespace NotificationAPI.Infrastructure.Persistence;
public class NotificationRepository : INotificationRepository
{
    private readonly INotificationDbContext _context;

    public NotificationRepository(INotificationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddAndCommitNotification(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.CommitAsync();
    }

    private bool disposedValue = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}