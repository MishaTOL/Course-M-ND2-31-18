using myDI;
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
            //1
            //ручной вариант
            //IDal mssqldal = new MSSQLDal();
            //IDal oracldal = new OracleDal();
            //Customer obj = new Customer(mssqldal);

            //2
            //framwork Unity
            //IUnityContainer objContainer = new UnityContainer();
            //objContainer.RegisterType<Customer>();
            //objContainer.RegisterType<IDal, MSSQLDal>();
            //objContainer.RegisterType<IDal, OracleDal>();
            //Customer obj = objContainer.Resolve<Customer>();

            //3 myself
            ImyDIRepository objContainer = new DIContainer();
            //objContainer.RegisterType<IDal, MSSQLDal>();
            objContainer.RegisterType<IDal, OracleDal>();
            IDal obj = objContainer.Resolver<IDal>();

            //
            obj.Add("test1");


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

    //Data Access Layer
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
