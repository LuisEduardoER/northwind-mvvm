namespace Northwind.Interfaces
{
    public interface IApplicationServices
    {
        INorthwindManager NorthwindManager { get; }
        IObjectFactory ObjectFactory { get; }
    }
}