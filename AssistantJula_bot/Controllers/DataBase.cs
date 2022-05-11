using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace AssistantJula_bot.Controllers;

internal sealed class DataBase<T> : IDataBase<T>
{
    public void ExecuteNonQuery(string queryString, T obj)
    {
        using SqlConnection connection = new(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
        SqlCommand command = new(queryString, connection);
        connection.Open();
        command.ExecuteNonQueryAsync();
    }

    public IEnumerable<T> Read(string queryString)
    {
        using SqlConnection connection = new(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
        SqlCommand command = new(queryString, connection);
        connection.Open();
        var reader = command.ExecuteReader();
        
        for(var i = 0; reader.Read(); i++)
        {
            yield return (T)reader[i];
        }
    }
}