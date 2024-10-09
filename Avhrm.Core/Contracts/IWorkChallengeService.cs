using Avhrm.Application.Features.WorkChallenge.Query.GetAllWorkChallenge;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Application;

[Service]
public interface IWorkChallengeService
{
    Task<List<GetAllWorkChallengeVm>> GetWorkChallengesByDepartmentId(CallContext context = default);
}
