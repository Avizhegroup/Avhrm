using Avhrm.Core.Common;
using Avhrm.Core.Features.WorkingReport.Command.DeleteWorkReport;
using Avhrm.Core.Features.WorkingReport.Command.SaveWorkReport;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Core.Features.WorkingReport.Query.GetWorkReportById;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IWorkReportService
{
    Task<List<GetUserWorkingReportByDateVm>> GetWorkingReportByDate(GetUserWorkingReportByDateQuery query, CallContext context = default);
    Task<SaveWorkReportCommand> GetWorkReportById(GetWorkReportByIdQuery query, CallContext context = default);
    Task<BaseDto<bool>> InsertWorkReport(SaveWorkReportCommand command, CallContext context = default);
    Task<BaseDto<bool>> UpdateWorkReport(SaveWorkReportCommand command, CallContext context = default);
    Task<BaseDto<bool>> DeleteWorkReport(DeleteWorkReportCommand command, CallContext context = default);
}
