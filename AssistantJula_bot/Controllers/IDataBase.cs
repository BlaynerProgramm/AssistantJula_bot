using System.Collections.Generic;

namespace AssistantJula_bot.Controllers;

internal interface IDataBase<T>
{
    void ExecuteNonQuery(string queryString, T obj);
    IEnumerable<T> Read(string queryString);
}