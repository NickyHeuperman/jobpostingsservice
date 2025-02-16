using Jex.JobPostings.Application.DTOs;
using MediatR;

namespace Jex.JobPostings.Application.Commands;

public class UpdateJobPostingCommand : IRequest<JobPosting>
{
    public UpdateJobPostingCommand(int id, string title, string? description, bool isActive)
    {
        Id = id;
        Title = title;
        Description = description;
        IsActive = isActive;
    }
    #region Parameters

    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }

    #endregion
}