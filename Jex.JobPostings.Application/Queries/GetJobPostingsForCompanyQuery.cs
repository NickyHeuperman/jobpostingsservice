using Jex.JobPostings.Application.DTOs;
using MediatR;

namespace Jex.JobPostings.Application.Queries;

public class GetJobPostingsForCompanyQuery : IRequest<IEnumerable<JobPosting>>
{
    public GetJobPostingsForCompanyQuery(int companyId, bool activeOnly = true)
    {
        CompanyId = companyId;
        ActiveOnly = activeOnly;
    }
    
    #region Parameters
    public int CompanyId { get; }
    public bool ActiveOnly { get; set; }
    #endregion
}