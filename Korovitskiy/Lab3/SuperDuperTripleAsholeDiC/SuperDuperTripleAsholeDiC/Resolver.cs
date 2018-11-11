using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public static class Resolver
    {
        public static Parent GetImplementation<Parent>() where Parent: class
        {
            Type childType = DIContainer.GetContainer().ContainerTypes[typeof(Parent)];
            var obj = childType.GetConstructor(new Type[] { }).Invoke(new object[] { });
            return (Parent)obj;
        }
    }
}
