using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Database.Contracts;

public interface ITagRepo
{
    Task<TagModel> CreateTag(string userId, DraftTagDto tag);

    Task<TagModel> UpdateTag(int tagId, DraftTagDto tag);

    Task<List<TagModel>> GetTags(string userId);

    Task DeleteTag(int id);
}