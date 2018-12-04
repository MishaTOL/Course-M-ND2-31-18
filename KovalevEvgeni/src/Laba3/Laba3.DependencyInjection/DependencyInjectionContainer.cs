using Laba3.DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.DependencyInjection
{
    public class DependencyInjectionContainer : IRepositoryDependencyInjection
    {
        private readonly Dictionary<Type, Type> container;

        public DependencyInjectionContainer()
        {
            container = new Dictionary<Type, Type>();
        }


        public void SetDependency<TSource, TClass>()
        {
            Type typeSource = typeof(TSource);
            Type typeClass = typeof(TClass);
            if ((!typeSource.IsClass && !typeSource.IsInterface) && !typeClass.IsClass)
            {
                throw new Exception($"incorrect input parameters");
            }
            foreach (var interfaces in typeClass.GetInterfaces())
            {
                if (typeSource.Name == interfaces.Name)
                {
                    if (!container.ContainsKey(typeSource))
                    {
                        container.Add(typeSource, typeClass);
                        return;
                    }
                    throw new Exception($"there is such a dependency");
                }
            }
            throw new Exception($"class {typeClass.Name} does not implement interface {typeSource.Name}");
        }

        public TSource GetDependency<TSource>()
        {
            Type typeSource = typeof(TSource);
            if (container.TryGetValue(typeSource, out Type typeClass))
            {
                return (TSource)Activator.CreateInstance(typeClass);
            }
            throw new Exception($"dependency for {typeSource.Name} not registered ");
        }

        public TSource GetDependency<TSource>(params object[] constructorInitialize)
        {
            Type typeSource = typeof(TSource);
            if (container.TryGetValue(typeSource, out Type typeClass))
            {
                Type[] typeParam = constructorInitialize.Select(x => x.GetType()).ToArray();
                ConstructorInfo constructor = typeClass.GetConstructor(typeParam);
                if (constructor != null)
                    return (TSource)constructor.Invoke(constructorInitialize);
                throw new Exception($"no constructor was found with the specified input parameters");
            }
            throw new Exception($"dependency for {typeSource.Name} not registered ");
        }
    }
}
