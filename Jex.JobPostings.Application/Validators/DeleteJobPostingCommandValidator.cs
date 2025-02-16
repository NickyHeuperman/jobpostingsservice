using FluentValidation;
using Jex.JobPostings.Application.Commands;
using Jex.JobPostings.Application.IService;

namespace Jex.JobPostings.Application.Validators;

public class DeleteJobPostingCommandValidator : AbstractValidator<DeleteJobPostingCommand>
{
    public DeleteJobPostingCommandValidator(IJobPostingService jobPostingService)
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0).MustAsync(async (id, _)=> await jobPostingService.ExistsAsync(id)).WithMessage("Jobposting does not exist");
    }
}