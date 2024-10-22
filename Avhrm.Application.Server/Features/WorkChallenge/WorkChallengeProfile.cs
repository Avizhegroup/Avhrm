using AutoMapper;
using Avhrm.Domains;

namespace Avhrm.Application.Server.Features;
public class WorkChallengeProfile : Profile
{
    public WorkChallengeProfile()
    {
        CreateMap<WorkChallenge, GetAllWorkChallengeDto>().ReverseMap();

        CreateMap<InsertWorkChallengeCommand, WorkChallenge>().ReverseMap();
    }
}
