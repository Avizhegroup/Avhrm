using AutoMapper;
using Avhrm.Domains;

namespace Avhrm.Application.Server.Features;
public class WorkTypeProfile : Profile
{
    public WorkTypeProfile()
    {
        CreateMap<WorkType, GetAllWorkTypesDto>().ReverseMap();
    }
}
