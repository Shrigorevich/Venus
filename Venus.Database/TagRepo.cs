using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Database;

public class TagRepo : BaseRepository, ITagRepo
{
    public TagRepo(IConfiguration configuration) : base(configuration)
    {
    }
    
    public async Task<TagModel> CreateTag(string userId, DraftTagDto tag)
    {
        await using var conn = Connection();

        var sql = $"INSERT INTO tag (user_id, name) VALUES (@user_id, @name) returning id, name";

        var result = await conn.QuerySingleAsync<TagModel>(sql, new
        {
            user_id = userId,
            name = tag.Name
        });
        
        return result;
    }

    public async Task<TagModel> UpdateTag(int tagId, DraftTagDto tag)
    {
        await using var conn = Connection();

        var sql = $"UPDATE tag SET name = @name WHERE id = @tagId";

        var result = await conn.QuerySingleAsync<TagModel>(sql, new
        {
            tagId,
            name = tag.Name
        });
        
        return result;
    }

    public async Task<List<TagModel>> GetTags(string userId)
    {
        await using var conn = Connection();

        var sql = $"SELECT id, name FROM tag WHERE user_id = @userId";

        var result = await conn.QueryAsync<TagModel>(sql, new
        {
            userId
        });
        
        return result.ToList();
    }

    public async Task DeleteTag(int id)
    {
        await using var conn = Connection();

        var sql = $"DELETE FROM tag WHERE id = @id";

        await conn.ExecuteAsync(sql, new
        {
            id
        });
    }
}