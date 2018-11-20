using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.DI
{
    public class Resolver
    {
        private readonly Container container;

        public Resolver(Container container)
        {
            this.container = container;
        }

        public TSource Get<TSource>()
        {
            var outputType = container.GetSourceClassType(typeof(TSource));
            var output = Activator.CreateInstance(outputType);
            return (TSource)output;
        }

        public TSource Get<TSource>(params object[] parameters)
        {
            var outputType = container.GetSourceClassType(typeof(TSource));
            try
            {
                var output = Activator.CreateInstance(outputType, parameters);
                return (TSource)output;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
