using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    internal class DIContainer
    {
        private static DIContainer container;
        private DIContainer()
        {
            ContainerTypes = new Dictionary<Type, Type>();
        }

        public static DIContainer GetContainer()
        {
            if (container == null)
                container = new DIContainer();
            return container;
        }

        internal Dictionary<Type, Type> ContainerTypes;




    }
}
