using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperTripleAsholeDiC
{
    public interface IRegistrator
    {
        void SetDependency<ParentType, ChildType>() where ChildType : ParentType;
    }
}
