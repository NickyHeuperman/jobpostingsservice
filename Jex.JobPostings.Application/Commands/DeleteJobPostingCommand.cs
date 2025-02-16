using MediatR;

namespace Jex.JobPostings.Application.Commands;

public record DeleteJobPostingCommand : IRequest<bool>
{
    public DeleteJobPostingCommand(int id)
    {
        Id = id;
    }
    public int Id { get; init; }
}