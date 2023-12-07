using Venus.Common;
using Venus.Database.Models;
using Venus.Dto;

namespace Venus.Database.Contracts;

public interface IChallengeRepo
{
    Task<List<ChallengeModel>> GetChallenges(string userId);
    
    Task<Guid> CreateChallenge(string userId, CreateChallengeDto challenge);

    Task UpdateChallengeStatus(Guid challengeId, ChallengeStatus status);
}