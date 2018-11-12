using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public static class SuperDuperDependencies
    {
        public static Parent GetImplementation<Parent>() where Parent : class
        {
            IResolver resolver = new Resolver(DIContainer.GetContainer());
            return resolver.GetImplementation<Parent>();
        }

        public static void SetDependency<Parent, Child>() where Parent : class where Child : Parent, new()
        {
            IRegistrator registrator = new Registrator(DIContainer.GetContainer());
            registrator.SetDependency<Parent, Child>();
        }
    }
}
