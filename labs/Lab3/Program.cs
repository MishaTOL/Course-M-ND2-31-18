using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Lab3
{
    //UI Layer
    class Program
    {

        static void Main(string[] args)
        {
            IUnityContainer objContainer = new UnityContainer();
            objContainer.RegisterType<Customer>();
            objContainer.RegisterType<IDal, MSSQLDal>();
            objContainer.RegisterType<IDal, OracleDal>();
            Customer obj = objContainer.Resolve<Customer>();
            obj.CustomerName = "test1";
            //Customer obj = new Customer(new MSSQLDal()) { CustomerName = "test1" };
            obj.Add(obj.CustomerName);

        }
    }
    //Middle layer
    public class Customer
    {
        private IDal Odal;
        public string CustomerName { get; set; }
        public Customer(IDal iobj)
        {
            Odal = iobj;
        }
        public void Add(string str)
        {
            //DAL

            Odal.Add(str);
        }
    }

    //DAL
    public interface IDal
    {
        void Add(string str);
    }
    public class MSSQLDal : IDal
    {
        public void Add(string str)
        {

            Console.WriteLine($"{str}:MSSQL Inserted!");
            Console.ReadLine();
        }
    }
    public class OracleDal : IDal
    {
        public void Add(string str)
        {

            Console.WriteLine($"{str}:Oracle Inserted!");
            Console.ReadLine();
        }
    }
}
