using System.Text.RegularExpressions;
using ErietaHairSalon.Application.Interfaces;
using ErietaHairSalon.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ErietaHairSalon.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class TransformationsController(ITransformationService transformationService) : ControllerBase
{
    private const string DefaultLanguage = "en";
    
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<TransformationResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<TransformationResponse>>> GetAll(
        [FromQuery] string? lang, 
        CancellationToken ct)
    {
        var language = lang is not null && TwoLetterCode().IsMatch(lang)
            ? lang.ToLowerInvariant()
            : DefaultLanguage;

        var items = await transformationService.GetActiveAsync(language, ct);
        return Ok(items);
    }

    [GeneratedRegex("^[a-zA-Z]{2}$")]
    private static partial Regex TwoLetterCode();
}
