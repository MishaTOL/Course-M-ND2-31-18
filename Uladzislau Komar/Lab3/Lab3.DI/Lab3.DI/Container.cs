using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.DI
{
    public class Container
    {
        private readonly IDictionary<Type, Type> container;

        public Container()
        {
            container = new Dictionary<Type, Type>();
        }

        public void Register<TSource, TClass>()
        {
            if ((typeof(TSource).IsClass || typeof(TSource).IsInterface)
                && typeof(TClass).IsClass)
            {
                container.Add(new KeyValuePair<Type, Type>(typeof(TSource), typeof(TClass)));
            }
            else
            {
                throw new Exception();
            }
        }

        internal Type GetSourceClassType(Type sourceType)
        {
            return container[sourceType];
        }
    }
}
