using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public class Resolver: IResolver
    {
        private DIContainer container;

        public Resolver(DIContainer container)
        {
            this.container = container;
        }

        public Parent GetImplementation<Parent>() where Parent: class
        {
            Type childType = this.container.DependencyContainer[typeof(Parent)];
            var obj = childType.GetConstructor(new Type[] { }).Invoke(new object[] { });
            return (Parent)obj;
        }
    }
}
