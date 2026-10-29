using ErietaHairSalon.Application.Interfaces;
using ErietaHairSalon.Application.Requests;
using ErietaHairSalon.Domain.Models;
using ErietaHairSalon.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace ErietaHairSalon.Infrastructure.Services;

public class InquiryService(
    ApplicationDbContext db,
    ILogger<InquiryService> logger) : IInquiryService
{
    public async Task CreateAsync(CreateInquiryRequest request, CancellationToken ct = default)
    {
        if (!string.IsNullOrWhiteSpace(request.Website))
        {
            logger.LogWarning("Honeypot field was filled in, inquiry discarded");
            return;
        }

        var inquiry = new Inquiry
        {
            SenderName = request.SenderName.Trim(),
            SenderEmail = request.SenderEmail.Trim(),
            SenderPhone = request.SenderPhone?.Trim(),
            Subject = request.Subject?.Trim(),
            Message = request.Message.Trim(),
            PreferredLanguage = request.PreferredLanguage
        };

        db.Inquiries.Add(inquiry);
        await db.SaveChangesAsync(ct);
        logger.LogInformation("Inquiry {InquiryId} saved", inquiry.Id);
    }
}
