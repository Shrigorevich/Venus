using Venus.Common;

namespace Venus.Dto;

public class CreateChallengeDayDto
{
    public ChallengeDayStatus Status { get; set; }
    
    /// <summary>
    /// Date representation in ISO format
    /// </summary>
    /// <example>2023-10-05T14:48:00.000Z</example>
    public string Date { get; set; }
    public Guid ChallengeId { get; set; }
}