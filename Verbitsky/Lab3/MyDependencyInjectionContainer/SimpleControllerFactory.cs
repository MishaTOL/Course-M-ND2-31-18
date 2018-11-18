using System;
using System.Web.Mvc;
using System.Web.Routing;
using MyDependencyInjectionContainer;
using MyDependencyInjectionContainer.Abstract;

namespace MyDependencyInjectionContainer
{
    public class SimpleControllerFactory : DefaultControllerFactory
    {
        private IContainer container;
        public SimpleControllerFactory(IContainer container)
        {
            this.container = container;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return container.Resolve(controllerType) as Controller;
        }
    }
}