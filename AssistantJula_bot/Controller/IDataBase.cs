using System.Collections.Generic;

namespace AssistantJula_bot.Controller;

internal interface IDataBase<T>
{
    void ExecuteNonQuery(string queryString, T obj);
    IEnumerable<T> Read(string queryString);
}