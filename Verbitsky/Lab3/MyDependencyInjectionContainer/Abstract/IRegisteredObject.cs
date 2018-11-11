using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDependencyInjectionContainer.Abstract
{
    interface IRegisteredObject
    {
        Type Left { get; set; }
        Type Right { get; set; }
        void With<TRitht>();
        object CreateInstance(params object[] args);
    }
}
