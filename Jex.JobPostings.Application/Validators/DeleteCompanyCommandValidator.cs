using FluentValidation;
using Jex.JobPostings.Application.Commands;
using Jex.JobPostings.Application.IService;

namespace Jex.JobPostings.Application.Validators;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator(IJobPostingService jobPostingService, ICompanyService companyService)
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x=>x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x=>x.Id).GreaterThan(0).MustAsync(async (id, _)=> await companyService.ExistsAsync(id)).WithMessage("Company does not exist");
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0).MustAsync(async (id, _) => !(await jobPostingService.GetJobPostingsForCompany(id, false)).Any()).WithMessage("Can't delete company with job postings");
    }
}