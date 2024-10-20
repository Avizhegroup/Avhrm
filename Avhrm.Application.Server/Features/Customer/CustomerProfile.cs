using AutoMapper;
using Avhrm.Domains;

namespace Avhrm.Application.Server.Features;
public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, GetAllCustomersDto>().ReverseMap();
    }
}
