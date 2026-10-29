using ErietaHairSalon.Application.Responses;

namespace ErietaHairSalon.Application.Interfaces;

public interface ITransformationService
{
    Task<IReadOnlyList<TransformationResponse>> GetActiveAsync(string language, CancellationToken ct = default);
}
