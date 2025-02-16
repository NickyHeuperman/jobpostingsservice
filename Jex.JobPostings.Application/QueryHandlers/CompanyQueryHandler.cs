using Jex.JobPostings.Application.DTOs;
using Jex.JobPostings.Application.IService;
using Jex.JobPostings.Application.Queries;
using MediatR;

namespace Jex.JobPostings.Application.QueryHandlers;

public class CompanyQueryHandler : IRequestHandler<GetAllCompaniesQuery, Company[]>
{
    private readonly ICompanyService _companyService;

    public CompanyQueryHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    
    public async Task<Company[]> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyService.GetAllAsync();
        return companies.ToArray();
    }
}
