namespace Jex.JobPostings.API.Requests;

public class CreateJobPostingRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}