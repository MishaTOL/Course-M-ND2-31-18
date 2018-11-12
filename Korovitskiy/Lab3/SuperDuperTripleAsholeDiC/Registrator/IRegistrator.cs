using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public interface IRegistrator
    {
        void SetDependency<Parent, Child>() where Parent : class where Child : Parent, new();
    }
}
