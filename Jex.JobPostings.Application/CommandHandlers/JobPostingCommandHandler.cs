using Jex.JobPostings.Application.Commands;
using Jex.JobPostings.Application.DTOs;
using Jex.JobPostings.Application.IService;
using MediatR;

namespace Jex.JobPostings.Application.CommandHandlers;

public class JobPostingCommandHandler : 
    IRequestHandler<CreateJobPostingCommand, JobPosting>,
    IRequestHandler<UpdateJobPostingCommand, JobPosting>,
    IRequestHandler<DeleteJobPostingCommand, bool>
{
    private readonly IJobPostingService _jobPostingService;

    public JobPostingCommandHandler(IJobPostingService jobPostingService)
    {
        _jobPostingService = jobPostingService;
    }
    public async Task<JobPosting> Handle(CreateJobPostingCommand request, CancellationToken cancellationToken)
    {
        return await _jobPostingService.AddAsync(new JobPosting{CompanyId = request.CompanyId,Title = request.Title, Description = request.Description, IsActive = request.IsActive});
    }

    public async Task<JobPosting> Handle(UpdateJobPostingCommand request, CancellationToken cancellationToken)
    {
        var jobPosting = await _jobPostingService.GetByIdAsync(request.Id);
        jobPosting.Description = request.Description;
        jobPosting.IsActive = request.IsActive;
        jobPosting.Title = request.Title;
        return await _jobPostingService.UpdateAsync(jobPosting);
    }

    public async Task<bool> Handle(DeleteJobPostingCommand request, CancellationToken cancellationToken)
    {
        return await _jobPostingService.DeleteAsync(request.Id);
    }
}