using Dapper;
using Dotsql.Repositories;
using own.Utilities;
using likes.models;


namespace likes.Repositories;
public interface ILikesRepository
{
    Task<Like> Create(Like like);
    Task Delete(long LikesId);
    Task<Like> GetById(long LikesId);


}
public class LikesRepository : BaseRepository, ILikesRepository
{
    public LikesRepository(IConfiguration config) : base(config)
    {

    }
    public async Task<Like> Create(Like like)
    {
        var query = $@"INSERT INTO {TableNames.likes} (user_id,post_id,created_datetime)
      VALUES (@UserId,@PostId,@CreatedDatetime)
      RETURNING *";
        using (var con = NewConnection)
            return await con.QuerySingleAsync<Like>(query, like);
    }

    // public Task<Like> Create(long LikesId)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task Delete(long LikesId)
    {
        var query = $@"DELETE FROM {TableNames.likes} WHERE likes_id = @Id";
        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { Id =LikesId });
    }

    public async Task<Like> GetById(long LikesId)
    {
        var query = $@"SELECT * FROM ""{TableNames.likes}""
          WHERE likes_id = @LikesId";

        using var con = NewConnection;
        Like like = await con.QuerySingleOrDefaultAsync<Like>(query, new {
                   LikesId = LikesId
               });
        return like;
    }
}