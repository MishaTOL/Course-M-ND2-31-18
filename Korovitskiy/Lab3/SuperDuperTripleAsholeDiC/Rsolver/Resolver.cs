using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public class Resolver: IResolver
    {
        private IContainer container;

        public Resolver(IContainer container)
        {
            this.container = container;
        }

        public ParentType GetImplementation<ParentType>() where ParentType: class
        {
            Type childType = this.container.DependencyContainer[typeof(ParentType)];
            var obj = childType.GetConstructor(new Type[] { }).Invoke(new object[] { });
            return (ParentType)obj;
        }
    }
}
