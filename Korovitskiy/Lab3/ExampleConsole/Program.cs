using SuperDuperTripleAsholeDiC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperDuperDependencies.SetDependency<ITestInterface, TestClass2>();

            ITestInterface exampleObject = SuperDuperDependencies.GetImplementation<ITestInterface>();
            Console.WriteLine(exampleObject.GetString());
            Console.Read();
        }
    }
}
