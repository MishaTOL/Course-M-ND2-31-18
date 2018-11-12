using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public class Registrator : IRegistrator
    {
        private DIContainer container;

        internal Registrator(DIContainer container)
        {
            this.container = container;
        }

        public void SetDependency<Parent, Child>() where Parent : class where Child : Parent, new()
        {
            Child child = new Child();
            Parent parent = child as Parent;
            if (parent == null)
                throw new Exception(nameof(Child) + " does not imlement " + nameof(parent));

            this.container.DependencyContainer.Add(typeof(Parent), typeof(Child));

        }
    }
}
