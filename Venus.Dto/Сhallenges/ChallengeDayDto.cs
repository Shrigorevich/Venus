using Venus.Common;

namespace Venus.Dto;

public class ChallengeDayDto
{
    public Guid Id { get; set; }
    public ChallengeDayStatus Status { get; set; }
    public DateTime Date { get; set; }
}