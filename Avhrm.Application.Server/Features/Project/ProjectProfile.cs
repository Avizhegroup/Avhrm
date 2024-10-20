using AutoMapper;
using Avhrm.Domains;

namespace Avhrm.Application.Server.Features;
public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, GetAllProjectsDto>().ReverseMap();
    }
}
