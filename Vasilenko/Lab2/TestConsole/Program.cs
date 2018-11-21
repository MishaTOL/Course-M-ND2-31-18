using Lab2.DataAccess.Abstraction;
using Lab2.DataAccess.Context;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IContext context = new EFContext();

            var a  = context.StudentsRepository.ToList();
            Console.WriteLine();
        }
    }
}
