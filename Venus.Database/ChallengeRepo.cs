using Dapper;
using Microsoft.Extensions.Configuration;
using Venus.Common;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Dto;

namespace Venus.Database;

public class ChallengeRepo : BaseRepository, IChallengeRepo
{
    public ChallengeRepo(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<List<ChallengeModel>> GetChallenges(string userId)
    {
        await using var conn = Connection();
        var sql = $"SELECT * from get_challenges('{userId}')";
        
        var result = await conn.QueryAsync<ChallengeModel>(sql);
        return result.ToList();
    }

    public async Task UpdateChallengeStatus(Guid challengeId, ChallengeStatus status)
    {
        await using var conn = Connection();
        var sql = $"UPDATE challenges SET status = {status} where id = '{challengeId}'";
        await conn.ExecuteAsync(sql);
    }

    public async Task<Guid> CreateChallenge(string userId, CreateChallengeDto challenge)
    {
        await using var conn = Connection();
        var sql = string.Format("SELECT * from create_challenge('{0}', '{1}', '{2}', '{3}', '{4}')", 
            userId, challenge.Name, challenge.Description, challenge.StartDate, challenge.EndDate);
        
        var result = await conn.QuerySingleAsync<Guid>(sql);
        return result;
    }
}