using AutoMapper;
using Avhrm.Domains;

namespace Avhrm.Application.Server.Features;
public class WorkingReportProfile : Profile
{
    public WorkingReportProfile()
    {
        CreateMap<WorkReport, InsertWorkReportCommand>()
            .ForMember(dest => dest.WorkChallengesIds, opt => opt.MapFrom(src => src.WorkChallenges.Select(p => p.Id)))
            .ReverseMap();

        CreateMap<WorkReport, GetUserWorkingReportByDateDto>()
            .ForMember(dest => dest.WorkTypeDescription, opt => opt.MapFrom(src => src.WorkType.Description));
 
        CreateMap<WorkReport, GetWorkReportByIdVm>()
            .ForMember(dest => dest.WorkChallengesIds, opt => opt.MapFrom(src => src.WorkChallenges.Select(p => p.Id)));

    }
}
