using Jex.JobPostings.API.Requests;
using Jex.JobPostings.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jex.JobPostings.API.Controllers.Command;

[ApiController]
[Tags("JobPosting")]
[Route("JobPosting")]
public class JobPostingCommandController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobPostingCommandController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPut("/Company/{companyId}/job-postings")]
    public async Task<IActionResult> Create([FromRoute] int companyId, [FromBody] CreateJobPostingRequest request)
    {
        var resp = await _mediator.Send(new CreateJobPostingCommand(companyId, request.Title, request.Description, request.IsActive));
        return Ok(resp);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateJobPostingRequest request)
    {
        var resp = await _mediator.Send(new UpdateJobPostingCommand(id, request.Title, request.Description, request.IsActive));
        return Ok(resp);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var resp = await _mediator.Send(new DeleteJobPostingCommand(id));
        return Ok(resp);
    }
    
}