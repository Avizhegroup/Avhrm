using Avhrm.Core.Features.WorkChallenge.Query.GetAllWorkChallenge;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IWorkChallengeService
{
    Task<List<GetAllWorkChallengeVm>> GetAllWorkChallenges(CallContext context = default);
}
