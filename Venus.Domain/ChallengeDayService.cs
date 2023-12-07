using Venus.Common;
using Venus.Dto;

namespace Venus.Domain;

public class ChallengeDayService : IChallengeDayService
{
    public Task<CreateChallengeDayDto> CreateChallengeDay(CreateChallengeDayDto day)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDayStatus(Guid dayId, ChallengeDayStatus status)
    {
        throw new NotImplementedException();
    }
}