using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public class Registrator : IRegistrator
    {
        private IContainer container;

        internal Registrator(IContainer container)
        {
            this.container = container;
        }

        public void SetDependency<ParentType, ChildType>() where ParentType : class where ChildType : ParentType, new()
        {
            ChildType child = new ChildType();
            ParentType parent = child as ParentType;

            if (parent == null)
                throw new Exception(typeof(ChildType) + " does not imlement " + typeof(ParentType));
            if (this.container.DependencyContainer.ContainsKey(typeof(ParentType)))
                throw new Exception(typeof(ParentType) + " already has implementation ");

            this.container.DependencyContainer.Add(typeof(ParentType), typeof(ChildType));

        }
    }
}
