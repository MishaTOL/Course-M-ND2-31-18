using System;

namespace Container
{
    public interface IResolver
    {
        object GetInstance(Type type);
    }
}
