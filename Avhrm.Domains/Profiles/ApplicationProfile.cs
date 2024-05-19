using AutoMapper;
using Avhrm.Core.Features.Customer.Query.GetAllCustomers;
using Avhrm.Core.Features.Project.Query.GetAllProjects;
using Avhrm.Core.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Core.Features.WorkingReport.Command.SaveWorkReport;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Core.Features.WorkType.Query.GetAllWorkTypes;

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
