using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class DeleteWorkReportHandler(AvhrmDbContext context) : IRequestHandler<DeleteWorkReportCommand, DeleteWorkReportVm>
{
    public async Task<DeleteWorkReportVm> Handle(DeleteWorkReportCommand request, CancellationToken cancellationToken)
    => new()
    {
        Result = context.WorkingReports.Where(p => p.Id == request.Id).ExecuteDelete() > 0
    };
} 
