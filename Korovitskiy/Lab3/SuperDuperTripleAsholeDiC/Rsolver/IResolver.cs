using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public interface IResolver
    {
        Parent GetImplementation<Parent>() where Parent : class;
    }
}
