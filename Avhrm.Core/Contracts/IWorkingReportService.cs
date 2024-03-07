using Avhrm.Core.Entities;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IWorkingReportService
{
    Task<List<WorkingReport>> GetWorkingReportByDate(GetUserWorkingReportByDateQuery query, CallContext context = default);
}
