using AutoMapper;
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
        CreateMap<WorkReport, SaveWorkReportCommand>().ReverseMap();

        CreateMap<WorkReport, GetUserWorkingReportByDateVm>();

        CreateMap<WorkChallenge, GetAllWorkChallengeVm>().ReverseMap();

        CreateMap<WorkType, GetAllWorkTypesVm>().ReverseMap();

        CreateMap<Project, GetAllProjectsVm>().ReverseMap();
    }
}
