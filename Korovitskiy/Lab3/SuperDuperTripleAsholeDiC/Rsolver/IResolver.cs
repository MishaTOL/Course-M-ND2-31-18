using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public interface IResolver
    {
        ParentType GetImplementation<ParentType>() where ParentType : class;
    }
}
