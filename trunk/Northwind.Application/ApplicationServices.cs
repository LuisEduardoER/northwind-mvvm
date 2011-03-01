using Northwind.Interfaces;

namespace Northwind.Application
{
    public class ApplicationServices : IApplicationServices
    {
        private readonly INorthwindManager _northwindManager;
        public INorthwindManager NorthwindManager { get { return _northwindManager; } }

        public ApplicationServices(INorthwindManager northwindManager)
        {
            _northwindManager = northwindManager;
        }
    }
}
