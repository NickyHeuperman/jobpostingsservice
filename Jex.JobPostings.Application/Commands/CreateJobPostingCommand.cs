using Jex.JobPostings.Application.DTOs;
using MediatR;

namespace Jex.JobPostings.Application.Commands;

public record CreateJobPostingCommand : IRequest<JobPosting>
{
    public CreateJobPostingCommand(int companyId, string title, string description, bool isActive)
    {
        CompanyId = companyId;
        Title = title;
        Description = description;
        IsActive = isActive;
    }
    public int CompanyId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}