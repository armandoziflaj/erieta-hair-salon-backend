using ErietaHairSalon.Application.Requests;

namespace ErietaHairSalon.Application.Interfaces;

public interface IInquiryService
{
    Task CreateAsync(CreateInquiryRequest request, CancellationToken ct = default);
}