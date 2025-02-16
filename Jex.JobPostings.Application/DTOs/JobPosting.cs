namespace Jex.JobPostings.Application.DTOs;

public record JobPosting : IDTO
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public int CompanyId { get; set; }
}