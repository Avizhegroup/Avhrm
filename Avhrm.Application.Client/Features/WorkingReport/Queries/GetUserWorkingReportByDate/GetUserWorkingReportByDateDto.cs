namespace Avhrm.Application.Client.Features;
public class GetUserWorkingReportByDateDto
{
    public int Id { get; set; }
    public string PersianDate { get; set; }
    public decimal SpentHours { get; set; }
    public string WorkTypeDescription { get; set; }
    public string Desc { get; set; }
}
