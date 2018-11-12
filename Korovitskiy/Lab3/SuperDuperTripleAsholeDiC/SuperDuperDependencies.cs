using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public static class SuperDuperDependencies
    {
        public static ParentType GetImplementation<ParentType>() where ParentType : class
        {
            IResolver resolver = new Resolver(DIContainer.GetContainer());
            return resolver.GetImplementation<ParentType>();
        }

        public static void SetDependency<ParentType, ChildType>() where ParentType : class where ChildType : ParentType, new()
        {
            IRegistrator registrator = new Registrator(DIContainer.GetContainer());
            registrator.SetDependency<ParentType, ChildType>();
        }
    }
}
