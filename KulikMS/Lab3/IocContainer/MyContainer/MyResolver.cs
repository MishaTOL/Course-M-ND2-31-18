using System;
using System.Collections.Generic;
using System.Linq;

namespace Container
{
    public class MyResolver : IResolver
    {
        private readonly IContainer container;
        public MyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetInstance(Type type)
        {
            var instanceType = container.GetInstanceType(type);
            if (instanceType == null)
            {
                throw new ArgumentException($"Type {type.Name} is not registered");
            }

            var constructorArgumets = GetConstructorArguments(instanceType).ToArray();
            return Activator.CreateInstance(instanceType, constructorArgumets);
        }

        private IEnumerable<object> GetConstructorArguments(Type type)
        {
            var constructor = type.GetConstructors()
                .Single();
            var argumentsTypes = constructor.GetParameters()
                .Select(s => s.ParameterType);

            var constructorArguments = new List<object>();
            foreach (var argumentType in argumentsTypes)
            {
                var argument = GetInstance(argumentType);
                constructorArguments.Add(argument);
            }

            return constructorArguments;
        }

    }
}
