using Avhrm.Core.Entities;
using ProtoBuf.Grpc;

namespace Avhrm.Core.Contracts;
public interface IProjectService
{
    Task<List<Project>> GetAllProjects(CallContext callContext = default);
}
