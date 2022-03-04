using Accelerex.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using IMediator = MediatR.IMediator;

namespace Accelerex.Api.Controllers;

[Route("api/convert")]
[ApiController]
public class ConverterController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConverterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Convert(WeekDays payload)
    {
        var result = await _mediator.Send(new ConvertWeekdays(payload));
        return Ok(result);
    }
    
    [HttpPost("inverter")]
    public async Task<ActionResult> Invert(int[] payload)
    {
        var result = await _mediator.Send(new InversePermute(payload));
        return Ok(result);
    }
}