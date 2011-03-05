using Ninject;
using Northwind.Data;
using Northwind.Interfaces;

namespace Northwind.Application
{
    public class NinjectObjectFactory : IObjectFactory
    {
        private readonly StandardKernel _kernel;

        public NinjectObjectFactory()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IApplicationServices>()
                .To<ApplicationServices>();
            _kernel.Bind<INorthwindManager>()
                .To<NorthwindManager>();
            _kernel.Bind<INorthwindRepository>()
                .To<SqlNorthwindRepository>();
        }

        public T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
