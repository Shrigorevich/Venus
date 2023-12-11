using Venus.Common;

namespace Venus.Dto;

public class CreateChallengeDayDto
{
    public ChallengeDayStatus Status { get; set; }
    
    /// <summary>
    /// Number of milliseconds elapsed since the epoch,
    /// which is defined as the midnight at the beginning of January 1, 1970, UTC
    /// </summary>
    public double Date { get; set; }
    public Guid ChallengeId { get; set; }
}