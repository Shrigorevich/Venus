using AutoMapper;
using Venus.Common;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Domain.Contracts;
using Venus.Dto;

namespace Venus.Domain;

public class ChallengeService : IChallengeService
{
    private readonly IChallengeRepo _challengeRepo;
    private readonly IMapper _mapper;

    public ChallengeService(IChallengeRepo challengeRepo, IMapper mapper)
    {
        _challengeRepo = challengeRepo;
        _mapper = mapper;
    }

    public async Task<List<ChallengeDto>> GetChallenges(string userId)
    {
        var challenges = await _challengeRepo.GetChallenges(userId);
        return _mapper.Map<List<ChallengeModel>, List<ChallengeDto>>(challenges);
    }

    public async Task<Guid> CreateChallenge(string userId, CreateChallengeDto challenge)
    {
        var id = await _challengeRepo.CreateChallenge(userId, challenge);
        return id;
    }

    public async Task UpdateChallengeStatus(Guid challengeId, ChallengeStatus status)
    {
        await _challengeRepo.UpdateChallengeStatus(challengeId, status);
    }
}