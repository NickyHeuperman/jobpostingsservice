using Jex.JobPostings.Application.DTOs;
using MediatR;

namespace Jex.JobPostings.Application.Commands;

public record CreateCompanyCommand : IRequest<Company>
{
    public CreateCompanyCommand(string name, string address)
    {
        Name = name;
        Address = address;
    }

    #region Parameters
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    #endregion
}