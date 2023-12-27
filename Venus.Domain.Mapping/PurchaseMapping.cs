using AutoMapper;
using Newtonsoft.Json;
using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Domain.Mapping;

public class PurchaseProfile : Profile
{
    public PurchaseProfile()
    {
        CreateMap<PurchaseModel, PurchaseViewDto>()
            .ForMember(
                dest => dest.Tags,
                opt => opt.MapFrom(x => JsonConvert.DeserializeObject<List<PurchaseTagDto>>(x.Tags)));
        
    }
}