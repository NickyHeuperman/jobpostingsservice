using Jex.JobPostings.Application.IRepository;
using Jex.JobPostings.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jex.JobPostings.Infrastructure;

public class JobPostingRepository : IJobPostingRepository
{
    private readonly JobPostingDbContext _dbContext;

    public JobPostingRepository(JobPostingDbContext dbContext)
    {
        //You'd never do this in an actual application, it's just here for convencience for now
        dbContext.Database.EnsureCreated();
        _dbContext = dbContext;
    }
    public Task<bool> ExistsAsync(int id)
    {
        return _dbContext.JobPostings.AnyAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<JobPosting>> GetAllAsync()
    {
        return await _dbContext.JobPostings.ToArrayAsync();
    }

    public async Task<JobPosting?> GetByIdAsync(int id)
    {
        return await _dbContext.JobPostings.AsNoTracking().SingleOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var jobPosting = _dbContext.JobPostings.SingleOrDefault(x => x.Id == id);
        if (jobPosting is null) return false;
        _dbContext.JobPostings.Remove(jobPosting);
        await _dbContext.SaveChangesAsync();
        return true;

    }

    public async Task<JobPosting> AddAsync(JobPosting jobPosting)
    {
        _dbContext.JobPostings.Add(jobPosting);
        await _dbContext.SaveChangesAsync();
        return jobPosting;
    }

    public async Task<JobPosting> UpdateAsync(JobPosting jobPosting)
    {
        _dbContext.Update(jobPosting);
        await _dbContext.SaveChangesAsync();
        return jobPosting;
    }

    public async Task<IEnumerable<JobPosting>> GetJobPostingsForCompany(int companyId, bool activeOnly)
    {
        return activeOnly ?
            await _dbContext.JobPostings.Where(x => x.CompanyId == companyId && x.IsActive).ToArrayAsync()
            : await _dbContext.JobPostings.Where(x => x.CompanyId == companyId).ToArrayAsync();
    }
}