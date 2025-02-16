using Jex.JobPostings.Application.DTOs;
using MediatR;

namespace Jex.JobPostings.Application.Commands;

public class UpdateCompanyCommand : IRequest<Company>
{
    public UpdateCompanyCommand(int id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }
    
    #region Parameters
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Id { get; set; }
    #endregion
}