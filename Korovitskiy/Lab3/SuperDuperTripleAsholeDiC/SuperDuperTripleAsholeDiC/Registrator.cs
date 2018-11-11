using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public static class Registrator
    {
        public static void RegisteringDependency<Parent, Child>() where Child : class, new() where Parent : class
        {
            Child t2 = new Child();
            Parent t1 = t2 as Parent;
            if (t1 == null)
                throw new Exception(nameof(Child) + " does not imlement " + nameof(t1));

            DIContainer.GetContainer().ContainerTypes.Add(typeof(Parent), typeof(Child));

        }
    }
}
