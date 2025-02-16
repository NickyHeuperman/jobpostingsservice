namespace Jex.JobPostings.API.Requests;

public class UpdateJobPostingRequest
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}