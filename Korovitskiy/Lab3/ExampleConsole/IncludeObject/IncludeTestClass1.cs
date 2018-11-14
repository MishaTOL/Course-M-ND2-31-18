using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConsole
{
    public class IncludeTestClass1 : IIncludeTestInterface
    {
        public string GetString()
        {
            return "test1";
        }
    }
}
