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
            IRegistrator registrator = new Registrator(DIContainer.GetContainer());
            registrator.SetDependency<ITestInterface, TestClass2>();
            registrator.SetDependency<IIncludeTestInterface, IncludeTestClass2>();

            IResolver resolver = new Resolver(DIContainer.GetContainer());
            var exampleObject = resolver.GetImplementation<ITestInterface>();
            
            Console.WriteLine(exampleObject.GetString());
            Console.Read();
        }
    }
}
