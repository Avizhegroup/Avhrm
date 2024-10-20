namespace Avhrm.Application.Client.Features;
public class GetUserByUsernameQuery : IRequest<GetUserByUsernameVm>
{
    [Required]
    public string Username { get; set; }
}
