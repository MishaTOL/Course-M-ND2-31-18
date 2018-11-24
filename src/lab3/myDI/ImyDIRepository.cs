using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDI
{
    public interface ImyDIRepository
    {
        void RegisterType<TSource, TClass>();
        TSource Resolver<TSource>();
    }
}
