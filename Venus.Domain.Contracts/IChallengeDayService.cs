using Venus.Common;
using Venus.Dto;

namespace Venus.Domain.Contracts;

public interface IChallengeDayService
{
    Task<ChallengeDayDto> CreateChallengeDay(CreateChallengeDayDto day);

    Task UpdateDayStatus(Guid dayId, ChallengeDayStatus status);
}