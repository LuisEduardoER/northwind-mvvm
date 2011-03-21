using Northwind.Interfaces;

namespace Northwind.Application
{
    public class ApplicationServices : IApplicationServices
    {
        private static IApplicationServices _instance;
        public static IApplicationServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance =
                        new ApplicationServices(new NinjectObjectFactory());
                }
                return _instance;
            }
            internal set { _instance = value; }
        }

        private INorthwindManager _northwindManager;
        public INorthwindManager NorthwindManager
        {
            get
            {
                if (_northwindManager == null)
                {
                    _northwindManager 
                        = ObjectFactory.Get<INorthwindManager>();
                }
                return _northwindManager;
            }
        }

        public IObjectFactory ObjectFactory { get; internal set; }

        //TODO: constructor should be private for singleton implementation
        private ApplicationServices(IObjectFactory objectFactory)
        {
            ObjectFactory = objectFactory;
        }
    }
}
