namespace Venus.Database.Models;

public class ChallengeDayModel
{
    public Guid Id { get; set; }
    public Guid ChallengeId { get; set; }
    public int Status { get; set; }
    public DateOnly Date { get; set; }
}