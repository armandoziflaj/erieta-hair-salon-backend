namespace ErietaHairSalon.Application.Responses;

/// <summary>
/// One before/after item for the public gallery.
/// Title and Description are already translated into the requested language.
/// </summary>
public record TransformationResponse(
    long Id,
    string Title,
    string? Description,
    string? BeforeImageUrl,
    string AfterImageUrl,
    string? ServiceTag);
