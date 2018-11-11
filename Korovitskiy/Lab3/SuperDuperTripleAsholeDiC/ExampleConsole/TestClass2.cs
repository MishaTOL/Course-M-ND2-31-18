using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConsole
{
    class TestClass2 : ITestInterface
    {
        public string GetString()
        {
            return "This is test class2";
        }
    }
}
