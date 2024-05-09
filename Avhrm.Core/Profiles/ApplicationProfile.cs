using AutoMapper;
using Avhrm.Core.Features.Project.Query.GetAllProjects;
using Avhrm.Core.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Core.Features.WorkingReport.Command;
using Avhrm.Core.Features.WorkType.Query.GetAllWorkTypes;

namespace Avhrm.Core;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<WorkReport, SaveWorkReportCommand>().ReverseMap();

        CreateMap<WorkChallenge, GetAllWorkChallengeVm>().ReverseMap();

        CreateMap<WorkType, GetAllWorkTypesVm>().ReverseMap();

        CreateMap<Project, GetAllProjectsVm>().ReverseMap();
    }
}
