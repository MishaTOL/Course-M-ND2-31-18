using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public interface IContainer
    {
        IDictionary<Type, Type> DependencyContainer { get; set; }
    }
}
