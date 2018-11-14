using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public class DIContainer : IContainer
    {
        private static object syncObject = new object();
        private static IContainer container;

        private DIContainer()
        {
            DependencyContainer = new Dictionary<Type, Type>();
        }

        public static IContainer GetContainer()
        {
            lock (syncObject)
            {
                if (container == null)
                    container = new DIContainer();
            }
            return container;
        }

        public IDictionary<Type, Type> DependencyContainer { get; set; }
    }
}
