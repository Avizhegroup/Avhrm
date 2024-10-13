using AutoMapper;
using Avhrm.Domains;

namespace Avhrm.Application.Server;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<WorkReport, InsertWorkReportCommand>()
            .ForMember(dest => dest.WorkChallengesIds, opt => opt.MapFrom(src => src.WorkChallenges.Select(p=>p.Id)))
            .ReverseMap();

        CreateMap<WorkReport, GetUserWorkingReportByDateDto>()
            .ForMember(dest => dest.WorkTypeDescription, opt => opt.MapFrom(src => src.WorkType.Description));

        CreateMap<WorkChallenge, GetAllWorkChallengeVm>().ReverseMap();

        CreateMap<WorkType, GetAllWorkTypesVm>().ReverseMap();

        CreateMap<Project, GetAllProjectsVm>().ReverseMap();

        CreateMap<Customer, GetAllCustomersVm>().ReverseMap();
    }
}
