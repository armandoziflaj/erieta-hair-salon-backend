using ErietaHairSalon.Application.Interfaces;
using ErietaHairSalon.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
 
namespace ErietaHairSalon.Api.Controllers;
 
[ApiController]
[Route("api/[controller]")]
public class InquiriesController(IInquiryService inquiryService) : ControllerBase
{
    /// <summary>Receives a message from the public contact form.</summary>
    [HttpPost]
    [EnableRateLimiting("inquiries")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    public async Task<IActionResult> Create(CreateInquiryRequest request, CancellationToken ct)
    {
        await inquiryService.CreateAsync(request, ct);
        
        return StatusCode(StatusCodes.Status201Created);
    }
}