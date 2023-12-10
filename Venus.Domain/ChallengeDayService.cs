using AutoMapper;
using Venus.Common;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Dto;

namespace Venus.Domain;

public class ChallengeDayService : IChallengeDayService
{
    private readonly IChallengeDayRepo _challengeDayRepo;
    private readonly IMapper _mapper;

    public ChallengeDayService(IChallengeDayRepo challengeDayRepo, IMapper mapper)
    {
        _challengeDayRepo = challengeDayRepo;
        _mapper = mapper;
    }

    public async Task<ChallengeDayDto> CreateChallengeDay(CreateChallengeDayDto day)
    {
        var challengeDay = await _challengeDayRepo.CreateChallengeDay(day);
        return _mapper.Map<ChallengeDayModel, ChallengeDayDto>(challengeDay);
    }

    public async Task UpdateDayStatus(Guid dayId, ChallengeDayStatus status)
    {
        await _challengeDayRepo.UpdateDayStatus(dayId, status);
    }
}