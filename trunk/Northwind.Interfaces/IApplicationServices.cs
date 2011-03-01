namespace Northwind.Interfaces
{
    public interface IApplicationServices
    {
        INorthwindManager NorthwindManager { get; }
    }
}