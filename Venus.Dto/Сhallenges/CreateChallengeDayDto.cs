using Venus.Common;

namespace Venus.Dto;

public class CreateChallengeDayDto
{
    public ChallengeDayStatus Status { get; set; }
    public DateOnly Date { get; set; }
    public Guid ChallengeId { get; set; }
}