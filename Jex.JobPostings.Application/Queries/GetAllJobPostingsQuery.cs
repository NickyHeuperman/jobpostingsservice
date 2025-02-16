﻿using Jex.JobPostings.Application.DTOs;
using MediatR;

namespace Jex.JobPostings.Application.Queries;

public class GetAllJobPostingsQuery : IRequest<IEnumerable<JobPosting>>
{
    
}