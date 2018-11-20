using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Infrastructure
{
    public class Container
    {
        private static Resolver instance = null;

        private static Resolver GetInstance()
        {
            if (instance == null)
                instance = new Resolver();

            return instance;
            
        }
        public static void Register<TFrom, TTo>()
        {
            GetInstance().Register<TFrom, TTo>();
        }

        public static T Resolve<T>()
        {
            return GetInstance().Resolve<T>();
        }
    }
}
