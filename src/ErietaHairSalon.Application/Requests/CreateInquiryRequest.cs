using System.ComponentModel.DataAnnotations;

namespace ErietaHairSalon.Application.Requests;

/// <summary>
/// Body of POST /api/inquiries (the public contact form).
/// Max lengths match the database column sizes in InquiryConfiguration.
/// </summary>
public record CreateInquiryRequest(
    [Required, StringLength(120, MinimumLength = 2)] string SenderName,
    [Required, EmailAddress, StringLength(200)] string SenderEmail,
    [Phone, StringLength(30)] string? SenderPhone,
    [StringLength(200)] string? Subject,
    [Required, StringLength(2000, MinimumLength = 10)] string Message,
    [RegularExpression("^[a-z]{2}$", ErrorMessage = "Use a two-letter language code, e.g. 'en' or 'el'.")]
    string PreferredLanguage = "en",
    // Honeypot: a hidden field real visitors never see or fill in. Bots usually fill every field.
    string? Website = null);