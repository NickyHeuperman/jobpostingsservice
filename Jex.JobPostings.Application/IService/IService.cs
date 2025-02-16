using Jex.JobPostings.Application.DTOs;

namespace Jex.JobPostings.Application.IService;

// ReSharper disable once InconsistentNaming
public interface IService<T> 
    where T : IDTO
{
    public Task<bool> ExistsAsync(int id);

    public Task<IEnumerable<T>> GetAllAsync();

    public Task<T> GetByIdAsync(int id);

    public Task<bool> DeleteAsync(int id);

    public Task<T> AddAsync(T entity);

    public Task<T> UpdateAsync(T entity);
}