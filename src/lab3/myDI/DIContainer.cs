using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDI
{
    public class DIContainer : ImyDIRepository
    {
        public Dictionary<Type, Type> mydic;
        public DIContainer()
        {
            mydic = new Dictionary<Type, Type>();
        }

        public void RegisterType<TSource, TClass>()
        {
            Type ts = typeof(TSource);
            Type tc = typeof(TClass);

            foreach (var item in tc.GetInterfaces())
            {
                if (ts.Name == item.Name)
                {
                    mydic.Add(ts, tc);
                }
            }

        }

        public TSource Resolver<TSource>()
        {
            Type ts = typeof(TSource);
            if (mydic.TryGetValue(ts, out Type tc))
            {
                return (TSource)Activator.CreateInstance(tc);
            }
            throw new Exception($"не найдено {ts.Name}");

        }
    }
}
