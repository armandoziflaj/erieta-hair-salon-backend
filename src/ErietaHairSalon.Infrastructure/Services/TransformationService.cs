using ErietaHairSalon.Application.Interfaces;
using ErietaHairSalon.Application.Responses;
using ErietaHairSalon.Domain.Common;
using ErietaHairSalon.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ErietaHairSalon.Infrastructure.Services;

public class TransformationService(ApplicationDbContext db) : ITransformationService
{
    public async Task<IReadOnlyList<TransformationResponse>> GetActiveAsync(
        string language, CancellationToken ct = default)
    {
        // Read-only query: no change tracking needed.
        // Uses the (IsActive, DisplayOrder) index defined in TransformationConfiguration.
        var items = await db.Transformations
            .AsNoTracking()
            .Where(t => t.IsActive)
            .OrderBy(t => t.DisplayOrder)
            .ThenBy(t => t.Id)
            .ToListAsync(ct);

        // Translation happens in memory: Localize() is C# code and can't be turned into SQL.
        return items
            .Select(t => new TransformationResponse(
                t.Id,
                t.Title.Localize(language),
                t.Description is { Count: > 0 } ? t.Description.Localize(language) : null,
                t.BeforeImageUrl,
                t.AfterImageUrl,
                t.ServiceTag))
            .ToList();
    }
}
