using System.Data;
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
        return new List<ChallengeModel>();
    }

    public async Task UpdateChallengeStatus(Guid challengeId, ChallengeStatus status)
    {
        throw new NotImplementedException();
    }

    public async Task<ChallengeModel> CreateChallenge(string userId, CreateChallengeDto challenge)
    {
        throw new NotImplementedException();
    }
}