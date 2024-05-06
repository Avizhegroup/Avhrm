using AutoMapper;
using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Core.Features.WorkChallenge.Query.GetWorkChallengeByIds;
using Avhrm.Core.Features.WorkingReport.Command;

namespace Avhrm.Core;
public class ApplicationProfile : Profile
{
    private readonly IWorkChallengeService workChallengeService;

    public ApplicationProfile(IWorkChallengeService workChallengeService)
    {
        this.workChallengeService = workChallengeService;

        CreateMap<WorkReport, SaveWorkReportCommand>()
            .ReverseMap()
            .ForMember(dest => dest.WorkChallenges, opt => opt.MapFrom(src => MapSelectedWorkChallenges(src.WorkChallengesIds)));

        CreateMap<WorkChallenge, GetWorkChallengeByIdsVm>().ReverseMap();
        CreateMap<WorkChallenge, GetAllWorkChallengeVm>().ReverseMap();
    }

    private ICollection<WorkChallenge> MapSelectedWorkChallenges(List<int> selectedIds)
    {
        var query = new GetWorkChallengeByIdsQuery()
        {
            Ids = selectedIds
        };

        var selectedWorkChallenges = workChallengeService.GetWorkChallengesByIds(query);
        return selectedWorkChallenges;
    }
}
