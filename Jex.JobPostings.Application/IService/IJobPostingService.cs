using JobPosting = Jex.JobPostings.Application.DTOs.JobPosting;

namespace Jex.JobPostings.Application.IService;

public interface IJobPostingService : IService<JobPosting>
{
    Task<IEnumerable<JobPosting>> GetJobPostingsForCompany(int companyId, bool activeOnly);
}