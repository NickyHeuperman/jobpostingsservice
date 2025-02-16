using Jex.JobPostings.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jex.JobPostings.API.Controllers.Query;
[ApiController]
[Tags("JobPosting")]
[Route("JobPosting")]
public class JobPostingQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobPostingQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("/Company/{companyId}/job-postings")]
    public async Task<IActionResult> Get([FromRoute] int companyId, [FromQuery] bool activeOnly = true)
    {
        var resp = await _mediator.Send(new GetJobPostingsForCompanyQuery(companyId, activeOnly));
        return Ok(resp);
    }
    
}