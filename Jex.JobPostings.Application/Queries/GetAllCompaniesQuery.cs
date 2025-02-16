using Jex.JobPostings.Application.DTOs;
using MediatR;

namespace Jex.JobPostings.Application.Queries;

public record GetAllCompaniesQuery : IRequest<Company[]>
{
    
}