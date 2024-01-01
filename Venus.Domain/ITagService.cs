using Venus.Dto.Accounting;

namespace Venus.Domain;

public interface ITagService
{
    Task<TagDto> CreateTag(string userId, DraftTagDto tag);

    Task<TagDto> UpdateTag(int tagId, DraftTagDto tag);

    Task<List<TagDto>> GetTags(string userId);

    Task DeleteTag(int id);
}