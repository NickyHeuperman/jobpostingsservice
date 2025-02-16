using FluentValidation;
using Jex.JobPostings.Application;
using Jex.JobPostings.Application.IRepository;
using Jex.JobPostings.Application.IService;
using Jex.JobPostings.Application.QueryHandlers;
using Jex.JobPostings.Application.Service;
using Jex.JobPostings.Application.Validators;
using Jex.JobPostings.Infrastructure;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Jex.JobPostings.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblyContaining<CompanyQueryHandler>());
        builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyCommandValidator>();
        builder.Services.AddFluentValidationAutoValidation();
        
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IJobPostingService, JobPostingService>();
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<IJobPostingRepository, JobPostingRepository>();
        builder.Services.AddScoped<JobPostingDbContext>();
        
        
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}