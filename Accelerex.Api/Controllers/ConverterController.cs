using Accelerex.Api.Entities;
using Accelerex.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accelerex.Api.Controllers;

[Route("api/convert")]
[ApiController]
public class ConverterController : ControllerBase
{
    private readonly IConverterService _converterService;

    public ConverterController(IConverterService converterService)
    {
        _converterService = converterService;
    }

    [HttpPost]
    public ActionResult<string> Convert(WeekDays payload)
    {
        return _converterService.ConvertToReadableText(payload);
    }
    
    [HttpPost("inverter")]
    public ActionResult<int[]> Invert(int[] payload)
    {
        return _converterService.InversePermutate(payload);
    }
}