using Venus.Common;

namespace Venus.Dto;

public class ChallengeDto
{
    public Guid Id { get; set; }
    public ChallengeStatus Status { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<ChallengeDayDto> Days { get; set; }
}