namespace Northwind.Interfaces
{
    public interface IObjectFactory
    {
        T Get<T>();
    }
}
