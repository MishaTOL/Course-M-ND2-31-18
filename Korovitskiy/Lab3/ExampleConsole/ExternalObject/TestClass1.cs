using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConsole
{
    class TestClass1 : ITestInterface
    {
        IIncludeTestInterface ob;
        public TestClass1(IIncludeTestInterface obj)
        {
            ob = obj;
        }
        public string GetString()
        {
            return ob.GetString();
        }
    }
}
