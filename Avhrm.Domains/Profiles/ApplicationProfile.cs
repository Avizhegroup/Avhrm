using AutoMapper;
using Avhrm.Application.Features.Customer.Query.GetAllCustomers;
using Avhrm.Application.Features.Project.Query.GetAllProjects;
using Avhrm.Application.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Application.Features.WorkingReport.Command.SaveWorkReport;
using Avhrm.Application.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Application.Features.WorkType.Query.GetAllWorkTypes;

namespace Avhrm.Domains;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<WorkReport, SaveWorkReportCommand>()
            .ForMember(dest => dest.WorkChallengesIds, opt => opt.MapFrom(src => src.WorkChallenges.Select(p=>p.Id)))
            .ReverseMap();

        CreateMap<WorkReport, GetUserWorkingReportByDateVm>()
            .ForMember(dest => dest.WorkTypeDescription, opt => opt.MapFrom(src => src.WorkType.Description));

        CreateMap<WorkChallenge, GetAllWorkChallengeVm>().ReverseMap();

        CreateMap<WorkType, GetAllWorkTypesVm>().ReverseMap();

        CreateMap<Project, GetAllProjectsVm>().ReverseMap();

        CreateMap<Customer, GetAllCustomersVm>().ReverseMap();
    }
}
