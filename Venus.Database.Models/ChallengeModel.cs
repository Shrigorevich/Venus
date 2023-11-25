namespace Venus.Database.Models;

public class ChallengeModel
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public int Status { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public List<ChallengeDayModel> Days { get; set; }
}