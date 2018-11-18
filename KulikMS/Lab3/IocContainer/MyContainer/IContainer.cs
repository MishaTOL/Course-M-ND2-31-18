using System;

namespace Container
{
    public interface IContainer
    {
        void RegisterType<T, K>() where K : class, T;
        Type GetInstanceType(Type type);
    }
}