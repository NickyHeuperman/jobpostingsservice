using MediatR;

namespace Jex.JobPostings.Application.Commands;

public class DeleteCompanyCommand : IRequest<bool>
{
    public DeleteCompanyCommand(int id)
    {
        Id = id;
    }
    
    #region Parameters
    public int Id { get; init; }
    #endregion
}