using Jex.JobPostings.API.Requests;
using Jex.JobPostings.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jex.JobPostings.API.Controllers.Command;

[ApiController]
[Route("Company")]
[Tags("Company")]
public class CompanyCommandController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyCommandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        var resp = await _mediator.Send(new CreateCompanyCommand(request.Name, request.Address));
        return Ok(resp);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyRequest request, [FromRoute] int id)
    {
        var resp = await _mediator.Send(new UpdateCompanyCommand(id, request.Name, request.Address));
        return Ok(resp);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany([FromRoute] int id)
    {
        var resp = await _mediator.Send(new DeleteCompanyCommand(id));
        return Ok(resp);
    }
    
}

