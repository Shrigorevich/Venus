using AutoMapper;
using Newtonsoft.Json;
using Venus.Common;
using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Domain.Mapping;

public class BudgetProfile : Profile
{
    public BudgetProfile()
    {
        CreateMap<BudgetModel, BudgetViewDto>()
            .ForMember(
                dest => dest.Tags,
                opt => opt.MapFrom(x => JsonConvert.DeserializeObject<List<TagDto>>(x.Tags)))
            .ForMember(dest => dest.Currency,
                opt => opt.MapFrom(x => new CurrencyDto(x.CurrencyId, x.CurrencyCode, x.CurrencyName)))
            .ForMember(dest => dest.Period, opt => opt.MapFrom(x => (BudgetPeriod)x.Period));
    }
}