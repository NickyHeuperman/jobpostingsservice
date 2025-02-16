using Jex.JobPostings.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jex.JobPostings.API.Controllers.Query;

[ApiController]
[Route("Company")]
[Tags("Company")]
public class CompanyQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var resp = await _mediator.Send(new GetAllCompaniesQuery());
        return Ok(resp);
    }
    
}