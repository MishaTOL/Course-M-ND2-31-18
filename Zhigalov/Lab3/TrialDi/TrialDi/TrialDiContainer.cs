using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TrialDi
{
    public class TrialDiContainer
    {
        private readonly IDictionary<Type, Type> registredTypes;

        public TrialDiContainer()
        {
            registredTypes = new Dictionary<Type, Type>();
        }

        public void Register<TKey, TConcrete>()
        {
            registredTypes[typeof(TKey)] = typeof(TConcrete);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type key)
        {
            Type concrete = registredTypes[key];
            ConstructorInfo constructorInfo = concrete.GetConstructors().FirstOrDefault();
            ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

            if (parameterInfos.Length == 0)
            {
                return Activator.CreateInstance(concrete);
            }

            List<object> parameters = new List<object>(parameterInfos.Length);
            foreach (ParameterInfo parameterInfo in parameterInfos)
            {
                parameters.Add(Resolve(parameterInfo.ParameterType));
            }
            return constructorInfo.Invoke(parameters.ToArray());
        }
    }
}
