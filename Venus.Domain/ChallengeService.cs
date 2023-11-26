using Venus.Common;
using Venus.Database.Contracts;
using Venus.Dto;

namespace Venus.Domain;

public class ChallengeService : IChallengeService
{
    private readonly IChallengeRepo _challengeRepo;

    public ChallengeService(IChallengeRepo challengeRepo)
    {
        _challengeRepo = challengeRepo;
    }

    public async Task<List<ChallengeDto>> GetChallenges(string userId)
    {
        await _challengeRepo.GetChallenges(userId);
        return new List<ChallengeDto>();
    }

    public async Task<ChallengeDto> CreateChallenge(string userId, CreateChallengeDto challenge)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateChallengeStatus(Guid challengeId, ChallengeStatus status)
    {
        throw new NotImplementedException();
    }
}