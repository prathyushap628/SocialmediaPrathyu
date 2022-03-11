using Dotnetsql.Models;
using Dapper;
using own.Utilities;

namespace Dotsql.Repositories;
public interface IUserRepository
{
    Task<User> Create(User Id);
    Task<bool> Update(User Id);
    Task<bool> Delete(long UserId);
    Task<User> GetById(long UserId);

}

public class UserRepository : BaseRepository, IUserRepository
{

    public UserRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<User> Create(User user)
    {
        User data = new User();
        try
        {
            var query = $@" INSERT INTO""{TableNames.user}"" (email_address, password, country, date_of_birth, given_name, surname)
        VALUES (@EmailAddress, @Password,@Country,@DateOfBirth,@GivenName,@Surname) 
        RETURNING *";
            using (var con = NewConnection)
            {
                data = await con.QuerySingleOrDefaultAsync<User>(query, user);
                return data;
            }
        }
        catch (Exception ex)
        {

        }
        return data;
    }

    public async Task<bool> Delete(long UserId)
    {
        var query = $@"DELETE FROM ""{TableNames.user}""
       WHERE user_id = @UserId";
        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { UserId });
            return res > 0;
        }
    }

    public async Task<User> GetById(long UserId)
    {
        var query = $@"SELECT * FROM ""{TableNames.user}""
          WHERE user_id = @userId";

        using (var con = NewConnection)
            try
            {
                return await con.QuerySingleOrDefaultAsync<User>(query,
               new
               {
                   userId = UserId
               });
            }
            catch (Exception ex)
            {

            }
        return default;
    }

    public async Task<bool> Update(User Id)
    {
        var query = $@"UPDATE ""{TableNames.user}"" SET email_address = @EmailAddress,password = @Password,
         country=@Country, given_name = @GivenName, surname = @Surname WHERE user_id = @UserId";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Id);
            return rowCount == 1;

        }

    }
}