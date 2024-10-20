using AutoMapper;
using Avhrm.Domains;
using Avhrm.Identity.Server.Utilities;
using Azure.Core;

namespace Avhrm.Application.Server.Features;
public class UserProfile : Profile
{
	public UserProfile()
	{
        CreateMap<ApplicationUser, GetAllUsersDto>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ReverseMap();

        CreateMap<InsertUserCommand, ApplicationUser>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => CryptographyTools.GetHashedStringSha256StringBuilder(src.Password)))
            .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.PersianName));

    }
}
