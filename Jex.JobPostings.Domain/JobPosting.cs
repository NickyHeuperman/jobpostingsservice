using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jex.JobPostings.Domain;

[Table("JobPosting")]

public class JobPosting: IEntity
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    [ForeignKey(nameof(Company))]
    public int CompanyId { get; set; }
    [InverseProperty(nameof(Company.JobPostings))]
    public virtual required Company Company { get; set; }
}