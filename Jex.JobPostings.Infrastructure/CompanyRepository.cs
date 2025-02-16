using Jex.JobPostings.Application.IRepository;
using Jex.JobPostings.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jex.JobPostings.Infrastructure;

public class CompanyRepository : ICompanyRepository
{
    private readonly JobPostingDbContext _dbContext;

    public CompanyRepository(JobPostingDbContext dbContext)
    {
        //You'd never do this in an actual application, it's just here for convencience for now
        dbContext.Database.EnsureCreated();
        _dbContext = dbContext;
        
    }
    public Task<bool> ExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        return await _dbContext.Companies.ToArrayAsync();
    }

    public async Task<Company?> GetByIdAsync(int id)
    {
        return await _dbContext.Companies.AsNoTracking().SingleOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var company = await GetByIdAsync(id);
        if (company is not null)
        {
            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<Company> AddAsync(Company company)
    {
        _dbContext.Companies.Add(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }

    public async Task<Company> UpdateAsync(Company company)
    {
        _dbContext.Companies.Update(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }
}