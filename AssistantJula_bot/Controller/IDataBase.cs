namespace AssistantJula_bot.Controller;

internal interface IDataBase<T>
{
    void Create(T obj);
    T Read();
    void Update(T obj, T obj2);
    void Delete(T obj);
}