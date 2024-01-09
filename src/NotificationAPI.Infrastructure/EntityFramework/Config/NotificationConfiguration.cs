using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationAPI.Domain.Aggregates;

namespace NotificationAPI.Infrastructure.EntityFramework.Config;
public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notification");

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Message).HasColumnName("Message").HasMaxLength(60);
        builder.Property(p => p.CreationDate).HasColumnName("CreationDate");

        builder.HasKey(p => p.Id);
    }
}
