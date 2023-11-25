using Venus.Common;
using Venus.Dto;

namespace Venus.Domain;

public interface IChallengeDayService
{
    Task<ChallengeDayDto> CreateChallengeDay(ChallengeDayDto day);

    Task UpdateDayStatus(Guid dayId, ChallengeDayStatus status);
}