using System;
using System.Collections.Generic;
using System.Linq;
using MyDependencyInjectionContainer.Abstract;

namespace MyDependencyInjectionContainer
{
    public class SimpleContainer : IContainer
    {
        private List<IRegisteredObject> registeredObjects;
        public SimpleContainer()
        {
            registeredObjects = new List<IRegisteredObject>();
        }
        public RegisteredObject Bind<TLeft>()
        {
            var registeredObject = new RegisteredObject() { Left = typeof(TLeft) };
            registeredObjects.Add(registeredObject);
            return registeredObject;
        }
        public object Resolve(Type Resolve)
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.Left == Resolve);
            return GetInstance(registeredObject);
        }
        private object GetInstance(IRegisteredObject registeredObject)
        {
            object[] parameters;
            var constructorParameters = registeredObject.Right.GetConstructors().First().GetParameters();
            if (constructorParameters.Count() > 0)
            {
                List<object> listParameters = new List<object>();
                foreach (var parameter in constructorParameters)
                {
                    listParameters.Add(Resolve(parameter.ParameterType));
                }
                parameters = listParameters.ToArray();
            }
            else
            {
                parameters = new object[0];
            }
            return registeredObject.CreateInstance(parameters);
        }
    }
}