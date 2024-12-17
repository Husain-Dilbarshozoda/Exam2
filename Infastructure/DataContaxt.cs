using Npgsql;

namespace Infastructure;

public class DataContaxt
{
    private readonly string connection = "Server=localhost;Port=5432;Database=jobboardmanagement_db;Username=postgres;Password=501040477.tj;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connection);
    }
}