using AutoMapper;
using Jex.JobPostings.Application.DTOs;
using Jex.JobPostings.Application.IRepository;
using Jex.JobPostings.Application.IService;

namespace Jex.JobPostings.Application.Service;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }
    
    public async Task<bool> ExistsAsync(int id)
    {
        return await _companyRepository.ExistsAsync(id);
    }

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        var companies = await _companyRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Company>>(companies);
    }

    public async Task<Company> GetByIdAsync(int id)
    {
        var company = await _companyRepository.GetByIdAsync(id);
        return _mapper.Map<Company>(company);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _companyRepository.DeleteAsync(id);
    }

    public async Task<Company> AddAsync(Company company)
    {
        var companyEntity = _mapper.Map<Domain.Company>(company);
        companyEntity =  await _companyRepository.AddAsync(companyEntity);
        return _mapper.Map<Company>(companyEntity);
    }

    public async Task<Company> UpdateAsync(Company company)
    {
        var companyEntity = _mapper.Map<Domain.Company>(company);
        companyEntity =  await _companyRepository.UpdateAsync(companyEntity);
        return _mapper.Map<Company>(companyEntity);
    }
}