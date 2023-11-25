using Venus.Common;

namespace Venus.Dto;

public class ChallengeDayDto
{
    public Guid Id { get; set; }
    public ChallengeDayStatus Status { get; set; }
    public DateOnly Date { get; set; }
}