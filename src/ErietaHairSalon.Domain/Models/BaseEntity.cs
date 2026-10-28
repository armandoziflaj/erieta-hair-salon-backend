using System.ComponentModel.DataAnnotations;

namespace ErietaHairSalon.Domain.Models;

public class BaseEntity
{
    public long Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
