using Avhrm.Core.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Core.Features.WorkChallenge.Query.GetWorkChallengeByIds;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IWorkChallengeService
{
    Task<List<GetAllWorkChallengeVm>> GetAllWorkChallenges(CallContext context = default);
    List<GetWorkChallengeByIdsVm> GetWorkChallengesByIds(GetWorkChallengeByIdsQuery query, CallContext context = default);
}
