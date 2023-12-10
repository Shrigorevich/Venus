using Venus.Common;
using Venus.Database.Models;
using Venus.Dto;

namespace Venus.Database.Contracts;

public interface IChallengeDayRepo
{
    Task<ChallengeDayModel> CreateChallengeDay(CreateChallengeDayDto day);

    Task UpdateDayStatus(Guid dayId, ChallengeDayStatus status);
}