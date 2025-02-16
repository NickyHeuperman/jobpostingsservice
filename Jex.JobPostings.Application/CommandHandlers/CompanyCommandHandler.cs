using Jex.JobPostings.Application.Commands;
using Jex.JobPostings.Application.DTOs;
using Jex.JobPostings.Application.IService;
using MediatR;

namespace Jex.JobPostings.Application.CommandHandlers;

public class CompanyCommandHandler : 
    IRequestHandler<CreateCompanyCommand, Company>,
    IRequestHandler<UpdateCompanyCommand, Company>,
    IRequestHandler<DeleteCompanyCommand, bool>
{
    private readonly ICompanyService _companyService;

    public CompanyCommandHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company
        {
            Name = request.Name,
            Address = request.Address,
        };
        company = await _companyService.AddAsync(company);
        return company;
    }

    public async Task<Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyService.GetByIdAsync(request.Id);
        company.Name = request.Name;
        company.Address = request.Address;
        return await _companyService.UpdateAsync(company);
    }

    public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        return await _companyService.DeleteAsync(request.Id);
    }
}