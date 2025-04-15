using System.Configuration;

using MySql.Data.MySqlClient;
public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;
    }


    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}
