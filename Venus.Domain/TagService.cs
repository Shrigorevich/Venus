using AutoMapper;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Domain;

public class TagService : ITagService
{
    private readonly IMapper _mapper;
    private readonly ITagRepo _tagRepo;
    
    public TagService(IMapper mapper, ITagRepo tagRepo)
    {
        _mapper = mapper;
        _tagRepo = tagRepo;
    }
    public async Task<TagDto> CreateTag(string userId, DraftTagDto tag)
    {
        var result = await _tagRepo.CreateTag(userId, tag);
        return _mapper.Map<TagModel, TagDto>(result);
    }

    public async Task<TagDto> UpdateTag(int tagId, DraftTagDto tag)
    {
        var result = await _tagRepo.UpdateTag(tagId, tag);
        return _mapper.Map<TagModel, TagDto>(result);
    }

    public async Task<List<TagDto>> GetTags(string userId)
    {
        var result = await _tagRepo.GetTags(userId);
        return _mapper.Map<List<TagModel>, List<TagDto>>(result);
    }

    public async Task DeleteTag(int id)
    {
        await _tagRepo.DeleteTag(id);
    }
}