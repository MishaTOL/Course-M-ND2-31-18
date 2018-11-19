using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public class Resolver : IResolver
    {
        private IContainer container;

        public Resolver(IContainer container)
        {
            this.container = container;
        }

        public ParentType GetImplementation<ParentType>() 
        {
            return (ParentType)GetImplementation(typeof(ParentType));
        }

        private object GetImplementation(Type parentType)
        {
            if (!this.container.DependencyContainer.ContainsKey(parentType))
            {
                throw new Exception("Not exist implementation");
            }

            Type implementator = this.container.DependencyContainer[parentType];
            IList<object> currentParametres = new List<object>();
            var constructorParamentrs = implementator.GetConstructors().OrderBy(x => x.GetParameters().Count())
                .FirstOrDefault().GetParameters();
            foreach (var param in constructorParamentrs)
            {
                var implementationOfParametr = this.GetImplementation(param.ParameterType);
                currentParametres.Add(implementationOfParametr);
            }
            return Activator.CreateInstance(implementator, currentParametres.ToArray());
        }
    }
}
