using AutoMapper;
using Avhrm.Domains;

namespace Avhrm.Application.Server.Features;
public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<Department, GetAllDepartmentDto>().ReverseMap();
    }
}
