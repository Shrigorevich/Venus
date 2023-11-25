using Venus.Common;
using Venus.Dto;

namespace Venus.Domain;

public interface IChallengeService
{
    Task<List<ChallengeDto>> GetChallenges(string userId);

    Task<ChallengeDto> CreateChallenge(string userId, CreateChallengeDto challenge);

    Task UpdateChallengeStatus(Guid challengeId, ChallengeStatus status);
}