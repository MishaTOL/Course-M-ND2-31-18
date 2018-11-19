using System;
using System.Collections.Generic;
using System.Reflection;

namespace DependencyInjection
{
    public class DIContainer
    {
        public IDictionary<Type, Type> DDependency { get; }
        public IDictionary<Type, DIConstructor> DConstructor{ get; }

        public DIContainer()
        {
            DDependency = new Dictionary<Type, Type>();
            DConstructor = new Dictionary<Type, DIConstructor>();
        }

        public void AddDependency<TInterface, TImplementation>()
        {
            DDependency[typeof(TInterface)] = typeof(TImplementation);
        }

        public void AddParameters<TInterface>(params dynamic[] parameters)
        {
            var type = DDependency[typeof(TInterface)]; //exception if not found
            var constructor = FindTheRightConstructor(type, parameters);
            if(constructor == null) { throw new ConstructorNotFoundException(type.Name); }
            var diConstructor = new DIConstructor() { Constructor = constructor, Parameters = parameters };
            DConstructor[type] = diConstructor;
        }

        private ConstructorInfo FindTheRightConstructor(Type type, dynamic[] parameters)
        {
            foreach (var constructor in type.GetConstructors())
            {
                var constructorParameters = constructor.GetParameters();
                if (parameters.Length != constructorParameters.Length) { continue; }
                bool parameterFlag = true;
                for (int i = 0; i < constructorParameters.Length; i++)
                {
                    if (parameters[i].GetType() != constructorParameters[i].ParameterType)
                    {
                        parameterFlag = false;
                        break;
                    }
                }
                if (!parameterFlag) { continue; }
                return constructor;
            }
            return null;
        }
    }
}
