using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NotificationAPI.Domain.Aggregates;
using System.Data;
using System.Reflection;

namespace NotificationAPI.Infrastructure.EntityFramework.Context;
public class NotificationDbContext : DbContext, INotificationDbContext
{
    public IDbConnection Connection => base.Database.GetDbConnection();
    private readonly IDbContextTransaction _currentTransaction;

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
    public DbSet<Notification> Notifications { get; set; }


    public NotificationDbContext()
    {
    }

    public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
: base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ////These configurations are useful while debuging the code. DON'T USE IN PRODUCTION
        //optionsBuilder
        //.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
        //.EnableDetailedErrors()
        //.EnableSensitiveDataLogging();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
            "Server=sqlserver;Database=db_notifications;User=sa;Password=Pass@word;TrustServerCertificate=True;");
        }
    }

    public async Task<bool> CommitAsync()
    {
        return await base.SaveChangesAsync() > 0;
    }
}