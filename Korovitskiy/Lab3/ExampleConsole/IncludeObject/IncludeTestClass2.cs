using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConsole
{
    public class IncludeTestClass2 : IIncludeTestInterface
    {
        public string GetString()
        {
            return "Test2";
        }
    }
}
