using Jex.JobPostings.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jex.JobPostings.Infrastructure;

public class JobPostingDbContext : DbContext
{
    public DbSet<JobPosting> JobPostings { get; set; }
    public DbSet<Company> Companies { get; set; }
    public string DbPath { get; set; }
    
    public JobPostingDbContext()
    {
        DbPath = Path.Combine(Environment.CurrentDirectory, "job-postings.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}