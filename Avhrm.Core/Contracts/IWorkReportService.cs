using Avhrm.Application.Common;
using Avhrm.Application.Features.WorkingReport.Command.DeleteWorkReport;
using Avhrm.Application.Features.WorkingReport.Command.SaveWorkReport;
using Avhrm.Application.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Application.Features.WorkingReport.Query.GetWorkReportById;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Application;

[Service]
public interface IWorkReportService
{
    Task<List<GetUserWorkingReportByDateVm>> GetWorkingReportByDate(GetUserWorkingReportByDateQuery query, CallContext context = default);
    Task<SaveWorkReportCommand> GetWorkReportById(GetWorkReportByIdQuery query, CallContext context = default);
    Task<BaseDto<bool>> InsertWorkReport(SaveWorkReportCommand command, CallContext context = default);
    Task<BaseDto<bool>> UpdateWorkReport(SaveWorkReportCommand command, CallContext context = default);
    Task<BaseDto<bool>> DeleteWorkReport(DeleteWorkReportCommand command, CallContext context = default);
}
