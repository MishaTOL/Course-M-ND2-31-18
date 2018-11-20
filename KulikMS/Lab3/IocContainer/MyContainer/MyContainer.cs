using System;
using System.Collections.Generic;

namespace Container
{
    public class MyContainer : IContainer
    {
        private readonly Dictionary<Type, Type> registeredTypes = new Dictionary<Type, Type>();
        public void RegisterType<T, K>() where K : class, T
        {
            if (registeredTypes.TryGetValue(typeof(T), out var instanceType))
            {
                registeredTypes[typeof(T)] = typeof(K);
                return;
            }
            
            registeredTypes.Add(typeof(T), typeof(K));
        }

        public Type GetInstanceType(Type type)
        {
            registeredTypes.TryGetValue(type, out var instanceType);
            return instanceType;
        }

    }
}
