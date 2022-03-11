using Dapper;
using Dotsql.Repositories;
using own.Utilities;
using post.models;

namespace post.Repositories;
public interface IPostRepository
{
    Task<Post> Create(Post post);
    Task Delete(long PostId);
    Task<Post> GetById(long postId);
    Task<List<Post>> GetPostHashtag(int HashtagId);

}
public class PostRepository : BaseRepository, IPostRepository
{
    public PostRepository(IConfiguration config) : base(config)
    {

    }
    public async Task<Post> Create(Post post)
    {
        var query = $@"INSERT INTO{TableNames.post} (user_id,written_text,media_location,created_datetime)
      VALUES (@UserId,@WrittenText,@MediaLocation,@CreatedDatetime)
      RETURNING *";
        using (var con = NewConnection)
            return await con.QuerySingleAsync<Post>(query, post);
    }

    public async Task Delete(long PostId)
    {
        var query = $@"DELETE FROM {TableNames.post} WHERE post_id = @PostId";
        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { PostId });
    }

    public async Task<Post> GetById(long PostId)
    {
        var query = $@"SELECT * FROM ""{TableNames.post}""
          WHERE post_id = @postId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Post>(query,
           new
           {
               postId = PostId
           });




    }


    //SELECT Customers.CustomerName, Orders.OrderID
    //FROM Customers
    //LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
    //ORDER BY Customers.CustomerName;

    public async Task<List<Post>> GetPostHashtag(int hashid)
    {
        try
        {
            // var query = $@"SELECT * FROM {TableNames.Hashtag_post} PostHashtag
            // LEFT JOIN {TableNames.post} post ON post.id = postHashtag.post_id 
            // // WHERE hashtag_id = @HashtagId";
            // var query = $@"select tag.* from {TableNames.hashtag_post} ph inner join {TableNames.hashtag} tag on 
            // ph.hashtag_id = tag.hashtag_id where ph.post_id = @PostId ";

            var query = $@"select po.* from {TableNames.post} po inner join {TableNames.post_hashtag} tag on po.post_id = tag.post_id 
	where tag.hashtag_id = @hashid";

            using (var con = NewConnection)
                return (await con.QueryAsync<Post>(query, new { hashid = hashid })).AsList();
        }
        catch (Exception ex)
        {

        }
        return default;

    }


}

