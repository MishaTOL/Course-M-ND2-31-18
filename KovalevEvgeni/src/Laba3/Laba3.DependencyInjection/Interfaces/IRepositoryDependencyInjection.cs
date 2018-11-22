
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.DependencyInjection.Interfaces
{
   public interface IRepositoryDependencyInjection
    {
        void SetDependency<TSource,TClass>();
        TSource GetDependency<TSource>();

        TSource GetDependency<TSource>(params object[] constructorInitialize);
    }
}
