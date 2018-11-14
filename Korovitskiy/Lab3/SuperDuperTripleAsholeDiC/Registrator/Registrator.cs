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

        public Registrator(IContainer container)
        {
            this.container = container;
        }

        public void SetDependency<ParentType, ChildType>() where ChildType : ParentType
        {
            if (this.container.DependencyContainer.ContainsKey(typeof(ParentType)))
            {
                throw new Exception(typeof(ParentType) + " already has implementation ");
            }
            this.container.DependencyContainer.Add(typeof(ParentType), typeof(ChildType));
        }
    }
}
