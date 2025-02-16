using FluentValidation;
using Jex.JobPostings.Application.Commands;
using Jex.JobPostings.Application.IService;

namespace Jex.JobPostings.Application.Validators;

public class CreateJobPostingCommandValidator : AbstractValidator<CreateJobPostingCommand>
{
    public CreateJobPostingCommandValidator(ICompanyService companyService)
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.CompanyId).NotEmpty().MustAsync(async (id, _) => await companyService.ExistsAsync(id)).WithMessage("Company not found");
    }
}