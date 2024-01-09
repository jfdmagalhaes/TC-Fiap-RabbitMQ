using System.Text.Json.Serialization;

namespace NotificationAPI.Domain.Aggregates;
public class Notification
{
    [JsonIgnore]
    public int Id { get; init; }
    public string Message { get; init; }
    public DateTime CreationDate { get; init; }
}