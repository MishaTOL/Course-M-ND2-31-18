using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Infrastructure
{
    public class Resolver
    {
        private Dictionary<Type, object> resolvedObjects;
        private Dictionary<Type, Type> registeredTypes;

        public Resolver()
        {
            resolvedObjects = new Dictionary<Type, object>();
            registeredTypes = new Dictionary<Type, Type>();
        }

        public T Resolve<T>()
        {
            if (!registeredTypes.ContainsKey(typeof(T)))
                throw new InvalidOperationException(string.Format("Requested type {0} has not been registered.", typeof(T).ToString()));

            Type destination = registeredTypes[typeof(T)];

            if (resolvedObjects.ContainsKey(destination))
                return (T)resolvedObjects[destination];

            T obj = (T)Activator.CreateInstance(destination);

            resolvedObjects.Add(destination, obj);

            return obj;
        }

        public void Register<TFrom, TTo>()
        {
            registeredTypes.Add(typeof(TFrom), typeof(TTo));
        }
    }
}
