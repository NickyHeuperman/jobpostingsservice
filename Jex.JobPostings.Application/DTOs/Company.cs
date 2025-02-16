namespace Jex.JobPostings.Application.DTOs;

public record Company : IDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }
}