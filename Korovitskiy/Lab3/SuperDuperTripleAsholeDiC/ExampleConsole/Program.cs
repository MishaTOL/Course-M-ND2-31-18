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
            Registrator.RegisteringDependency<ITestInterface, TestClass2>();

            var obj = Resolver.GetImplementation<ITestInterface>();
            Console.WriteLine(obj.GetString());
            Console.Read();
        }
    }
}
