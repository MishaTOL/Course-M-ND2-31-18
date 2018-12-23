using Laba3.DataAccessLayer.Repository;
using Laba3.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba3.DependencyInjection;
using Laba3.DependencyInjection.Interfaces;

namespace Laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositoryDependencyInjection dependencyInjection = new DependencyInjectionContainer();
            dependencyInjection.SetDependency<IRepository, OneRepository>();
            IRepository repository = dependencyInjection.GetDependency<IRepository>();
            Console.WriteLine(repository.ViewDetails());

            IRepositoryDependencyInjection dependencyInjectionTwo = new DependencyInjectionContainer();
            dependencyInjectionTwo.SetDependency<IRepository, TwoRepository>();
            IRepository repositoryTwo = dependencyInjectionTwo.GetDependency<IRepository>("Helloy");
            Console.WriteLine(repositoryTwo.ViewDetails());

            repositoryTwo = dependencyInjectionTwo.GetDependency<IRepository>();
            Console.WriteLine(repositoryTwo.ViewDetails());
            Console.ReadKey();
        }
    }
}
