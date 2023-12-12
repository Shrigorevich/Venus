using Dapper;
using Microsoft.Extensions.Configuration;
using Venus.Common;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Dto;

namespace Venus.Database;

public class ChallengeDayRepo : BaseRepository, IChallengeDayRepo
{
    public ChallengeDayRepo(IConfiguration configuration) : base(configuration)
    {
    }
    
    public async Task<ChallengeDayModel> CreateChallengeDay(CreateChallengeDayDto day)
    {
        await using var conn = Connection();
        var sql = $"SELECT * FROM add_challenge_day('{day.ChallengeId}', {(int)day.Status}, '{day.Date}')";
        var challengeDay = await conn.QuerySingleAsync<ChallengeDayModel>(sql);
        return challengeDay;
    }

    public async Task UpdateDayStatus(Guid dayId, ChallengeDayStatus status)
    {
        await using var conn = Connection();
        var sql = $"UPDATE challenge_day SET status = {(int)status} where id = '{dayId}'";
        await conn.ExecuteAsync(sql);
    }

    
}