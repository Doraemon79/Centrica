using Microsoft.Data.SqlClient;
using System.Data;

namespace CentricaStoresApi.Data;

public class CentricaDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionstring;
    public CentricaDbContext(IConfiguration configuration)
    {

        this._configuration = configuration;
        this._connectionstring = this._configuration.GetConnectionString("connection");

    }
    public IDbConnection CreateConnection()
    {
        var tst = new SqlConnection(_connectionstring);
        return tst;
    }
}
