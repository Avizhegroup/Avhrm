using ProtoBuf;

namespace Avhrm.Core.Features.WorkChallenge.Query.GetWorkChallengeByIds;

[ProtoContract]
public class GetWorkChallengeByIdsQuery
{
    [ProtoMember(1)]
    public List<int> Ids { get; set; }
}
