namespace ErietaHairSalon.Domain.Models;

public class Transformation : BaseEntity
{
    public Dictionary<string, string> Title { get; set; } = new();
    public Dictionary<string, string>? Description { get; set; }
    public string? BeforeImageUrl { get; set; }
    public string AfterImageUrl { get; set; } = string.Empty;
    public string? ServiceTag { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public bool IsActive { get; set; } = true;
}