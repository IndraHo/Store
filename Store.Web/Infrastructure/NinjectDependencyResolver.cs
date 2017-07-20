using Ninject;
using Store.Domain.Abstract;
using Store.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mKernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            mKernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            mKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }

        public object GetService(Type serviceType)
        {
            return mKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return mKernel.GetAll(serviceType);
        }
    }
}