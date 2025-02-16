using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jex.JobPostings.Domain;

[Table("Company")]
public class Company : IEntity
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }
    [InverseProperty(nameof(JobPosting.Company))]
    public ICollection<JobPosting>? JobPostings { get; set; }
}