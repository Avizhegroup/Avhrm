namespace Avhrm.Application.Client.Features;
public class GetWorkReportOfChildUsersDto
{
    public int Id { get; set; }
    public string PersianDate { get; set; }
    public string Desc { get; set; }
    public decimal SpentHours { get; set; }
    public string PersianName { get; set; }
}
