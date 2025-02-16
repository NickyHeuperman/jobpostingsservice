using AutoMapper;
using Entities =  Jex.JobPostings.Domain;

namespace Jex.JobPostings.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Entities.Company, DTOs.Company>().ReverseMap();
        CreateMap<Entities.JobPosting, DTOs.JobPosting>().ReverseMap();
    }
}