namespace Avhrm.Domains;
public class WorkReportWorkChallenge
{
    public int WorkReportId { get; set; }
    public int WorkChallengeId { get; set; }

    public WorkReport WorkReport { get; set; }
    public WorkChallenge WorkChallenge { get; set; }
}
