using AutoMapper;
using Newtonsoft.Json;
using Venus.Database.Models;
using Venus.Dto;

namespace Venus.Domain.Mapping;

public class ChallengeProfile : Profile
{

    public ChallengeProfile()
    {
        CreateMap<ChallengeModel, ChallengeDto>()
            .ForMember(
                dest => dest.Days, opt => opt.MapFrom(x => JsonConvert.DeserializeObject<List<ChallengeDayDto>>(x.Days)));
    }
}