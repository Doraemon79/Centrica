namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters, string connectionId = "connection");
    Task SaveData<T>(string storeProcedure, T parameters, string connectionId = "connection");
}