using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    [Serializable]
    class ConstructorNotFoundException : Exception
    {
        public ConstructorNotFoundException()
        {

        }

        public ConstructorNotFoundException(string name)
            : base(String.Format("Suitable constructor for type {0} not found", name))
        {

        }

    }
}
