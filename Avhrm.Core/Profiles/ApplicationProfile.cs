using AutoMapper;
using Avhrm.Application.Features;
using Avhrm.Domains;

namespace Avhrm.Application.Server;;
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
