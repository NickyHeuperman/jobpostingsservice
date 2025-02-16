using Jex.JobPostings.Domain;

namespace Jex.JobPostings.Application.IRepository;

public interface IJobPostingRepository : IRepository<JobPosting>
{
    Task<IEnumerable<JobPosting>> GetJobPostingsForCompany(int companyId, bool activeOnly);
}