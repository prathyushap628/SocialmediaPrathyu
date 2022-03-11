using System.Data;
using Dotsql.Settings;
using Npgsql;


namespace Dotsql.Repositories;

public class BaseRepository
{
    private readonly IConfiguration _Configuration;

    public BaseRepository(IConfiguration configuration)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        _Configuration = configuration;
    }
    public NpgsqlConnection NewConnection => new NpgsqlConnection(_Configuration
    .GetSection(nameof(PostgresSettings)).Get<PostgresSettings>().ConnectionString);




}


