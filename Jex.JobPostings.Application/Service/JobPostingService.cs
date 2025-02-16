using AutoMapper;
using Jex.JobPostings.Application.DTOs;
using Jex.JobPostings.Application.IRepository;
using Jex.JobPostings.Application.IService;
namespace Jex.JobPostings.Application.Service;

public class JobPostingService : IJobPostingService
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;

    public JobPostingService(IJobPostingRepository jobPostingRepository, IMapper mapper)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
    }
    public async Task<bool> ExistsAsync(int id)
    {
        return await _jobPostingRepository.ExistsAsync(id); 
    }

    public async Task<IEnumerable<JobPosting>> GetAllAsync()
    {
        var jobPostings = await _jobPostingRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<JobPosting>>(jobPostings);
    }

    public async Task<JobPosting> GetByIdAsync(int id)
    {
        var jobPosting = await _jobPostingRepository.GetByIdAsync(id);
        return _mapper.Map<JobPosting>(jobPosting);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _jobPostingRepository.DeleteAsync(id);
    }

    public async Task<JobPosting> AddAsync(JobPosting jobPosting)
    {
        var jobPostingEntity = _mapper.Map<Domain.JobPosting>(jobPosting);
        jobPostingEntity = await _jobPostingRepository.AddAsync(jobPostingEntity);
        return _mapper.Map<JobPosting>(jobPostingEntity);
    }

    public async Task<JobPosting> UpdateAsync(JobPosting jobPosting)
    {
        var jobPostingEntity = _mapper.Map<Domain.JobPosting>(jobPosting);
        jobPostingEntity =  await _jobPostingRepository.UpdateAsync(jobPostingEntity);
        return _mapper.Map<JobPosting>(jobPostingEntity);
    }

    public async Task<IEnumerable<JobPosting>> GetJobPostingsForCompany(int companyId, bool activeOnly)
    {
        var jobPostings = await  _jobPostingRepository.GetJobPostingsForCompany(companyId, activeOnly);
        return _mapper.Map<IEnumerable<JobPosting>>(jobPostings);
    }
}