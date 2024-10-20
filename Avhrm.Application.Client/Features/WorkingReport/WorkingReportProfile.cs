using AutoMapper;

namespace Avhrm.Application.Client.Features;
public class WorkingReportProfile : Profile
{
    public WorkingReportProfile()
    {
        CreateMap<InsertWorkReportCommand, UpdateWorkReportCommand>();

 CreateMap<GetWorkReportByIdVm, InsertWorkReportCommand>();
    }
}
