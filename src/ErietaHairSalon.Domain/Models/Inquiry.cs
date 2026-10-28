namespace ErietaHairSalon.Domain.Models;

public class Inquiry : BaseEntity
{
    public required string SenderName { get; set; }
    public required string SenderEmail { get; set; }
    public string? SenderPhone { get; set; }
    public string? Subject { get; set; } 
    public required string Message { get; set; }
    public string PreferredLanguage { get; set; } = "en";
    public bool IsEmailSent { get; set; }
    public bool IsRead { get; set; }
}