using AutoMapper;
using Avhrm.Core.Features.WorkingReport.Command;

namespace Avhrm.Core;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<SaveWorkReportCommand, WorkReport>().ReverseMap();
    }
}
