using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public class DIContainer
    {
        private static object syncObject = new object();
        private static DIContainer container;

        private DIContainer()
        {
            DependencyContainer = new Dictionary<Type, Type>();
        }

        public static DIContainer GetContainer()
        {
            lock (syncObject)
            {
                if (container == null)
                    container = new DIContainer();
            }
            return container;
        }

        public Dictionary<Type, Type> DependencyContainer;
    }
}
