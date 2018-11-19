using System;

namespace MyDependencyInjectionContainer.Abstract
{
    public interface IContainer
    {
        RegisteredObject Bind<TResolve>();
        object Resolve(Type typeToResolve);
    }
}