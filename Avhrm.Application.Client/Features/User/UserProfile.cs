using AutoMapper;

namespace Avhrm.Application.Client.Features;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<GetUserByUsernameVm, InsertUserCommand > ();
    }
}
