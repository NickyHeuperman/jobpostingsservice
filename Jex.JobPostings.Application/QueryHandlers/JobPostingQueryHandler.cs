using Jex.JobPostings.Application.DTOs;
using Jex.JobPostings.Application.IService;
using Jex.JobPostings.Application.Queries;
using MediatR;

namespace Jex.JobPostings.Application.QueryHandlers;

public class JobPostingQueryHandler : IRequestHandler<GetJobPostingsForCompanyQuery,IEnumerable<JobPosting>>
{
    private readonly IJobPostingService _jobPostingService;

    public JobPostingQueryHandler(IJobPostingService jobPostingService)
    {
        _jobPostingService = jobPostingService;
    }

    public Task<IEnumerable<JobPosting>> Handle(GetJobPostingsForCompanyQuery request, CancellationToken cancellationToken)
    {
        return _jobPostingService.GetJobPostingsForCompany(request.CompanyId, request.ActiveOnly);
    }
}