using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConsole
{
    class TestClass2 : ITestInterface
    {
        IIncludeTestInterface ob;
        public TestClass2(IIncludeTestInterface obj)
        {
            ob = obj;
        }

        public string GetString()
        {
            return ob.GetString();
        }
    }
}
