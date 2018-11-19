using DependencyInjection;
using Lab3.Interfaces;
using Lab3.Services;
using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new DIContainer();
            container.AddDependency<IStudent, Student1>();
            container.AddParameters<IStudent>();
            var resolver = new DIResolver(container);
            var student = resolver.Get<IStudent>();
            student.Write();

            var container1 = new DIContainer();
            container1.AddDependency<IStudent, Student2>();
            container1.AddParameters<IStudent>(new List<string>() {"Aleshka", "Inokentiy", "Eduard"});
            var resolver1 = new DIResolver(container1);
            var student1 = resolver1.Get<IStudent>();
            student1.Write();
            Console.ReadLine();
        }
    }
}
