using Venus.Common;
using Venus.Dto;

namespace Venus.Domain.Contracts;

public interface IChallengeService
{
    Task<List<ChallengeDto>> GetChallenges(string userId);

    Task<Guid> CreateChallenge(string userId, CreateChallengeDto challenge);

    Task UpdateChallengeStatus(Guid challengeId, ChallengeStatus status);
}