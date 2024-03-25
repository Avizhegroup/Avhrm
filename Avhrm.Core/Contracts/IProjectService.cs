using Avhrm.Core.Entities;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IProjectService
{
    Task<List<Project>> GetAllProjects(CallContext callContext = default);
}
