using AutoMapper;
using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Domain.Mapping;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<TagModel, TagDto>();
    }
}