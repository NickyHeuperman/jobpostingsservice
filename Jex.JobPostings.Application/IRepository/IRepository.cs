using Jex.JobPostings.Domain;

namespace Jex.JobPostings.Application.IRepository;

public interface IRepository<T> where T : IEntity
{
    public Task<bool> ExistsAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<T> AddAsync(T company);
    Task<T> UpdateAsync(T company);   
}