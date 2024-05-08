using AutoMapper;
using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Core.Features.WorkChallenge.Query.GetWorkChallengeByIds;
using Avhrm.Core.Features.WorkingReport.Command;

namespace Avhrm.Core;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<WorkReport, SaveWorkReportCommand>().ReverseMap();

        CreateMap<WorkChallenge, GetAllWorkChallengeVm>().ReverseMap();
    }
}
