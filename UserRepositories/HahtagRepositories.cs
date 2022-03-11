using Dotnetsql.Models;
using Dapper;
using own.Utilities;
using hashtag.models;

namespace Dotsql.Repositories;
public interface IHashtagRepository
{
    Task<Hashtag> Create(Hashtag Id);
    Task<bool> Update(Hashtag Id);
    Task<bool> Delete(long HashtagId);
    Task<Hashtag> GetById(long HashtagId);

}

public class HashtagRepository : BaseRepository, IHashtagRepository
{

    public HashtagRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Hashtag> Create(Hashtag Hashtag)
    {
        Hashtag data = new Hashtag();
        try
        {
            var query = $@" INSERT INTO""{TableNames.hashtag}""(hashtag_name, post_id, user_id)
        VALUES(@HashtagName,@PostId,@UserId) 
        RETURNING *";
            using (var con = NewConnection)
            {
                data = await con.QuerySingleOrDefaultAsync<Hashtag>(query, Hashtag);
                return data;
            }
        }
        catch (Exception ex)
        {

        }
        return data;
    }

    public async Task<bool> Delete(long HashtagId)
    {
        var query = $@"DELETE FROM ""{TableNames.hashtag}""
       WHERE Hashtag_id = @HashtagId";
        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { HashtagId });
            return res > 0;
        }
    }

    public async Task<Hashtag> GetById(long HashtagId)
    {
        var query = $@"SELECT * FROM ""{TableNames.hashtag}""
          WHERE Hashtag_id = @HashtagId";

        using (var con = NewConnection)
            try
            {
                return await con.QuerySingleOrDefaultAsync<Hashtag>(query,
               new
               {
                   HashtagId = HashtagId
               });
            }
            catch (Exception ex)
            {

            }
        return default;
    }

    public async Task<bool> Update(Hashtag Id)
    {
        var query = $@"UPDATE ""{TableNames.hashtag}"" SET hashtag_name = @HashtagName";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Id);
            return rowCount == 1;

        }

    }
}