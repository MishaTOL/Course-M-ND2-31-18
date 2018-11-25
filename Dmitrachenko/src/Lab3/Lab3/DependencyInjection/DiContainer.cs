using System;
using System.Collections.Generic;

namespace Lab3.Util
{
    public class DiContainer
    {
        public Dictionary<Type, Type> container;

        public DiContainer()
        {
            container = new Dictionary<Type, Type>();
        }

        public void Register<TInterface, TClass>()
        {
            Type typeInterface = typeof(TInterface);
            Type typeClass = typeof(TClass);
            if ((!typeInterface.IsClass && !typeInterface.IsInterface) && !typeClass.IsClass)
            {
                throw new Exception("Неверные параметры");
            }
            foreach (var nameInterface in typeClass.GetInterfaces())
            {
                if (typeInterface.Name == nameInterface.Name)
                {
                    if (!container.ContainsKey(typeInterface))
                    {
                        container.Add(typeInterface, typeClass);
                        return;
                    }
                    throw new Exception("Данный тип интерфейса уже зарегистрирован");
                }
            }
            throw new Exception($"Класс {typeClass.Name} не реализует интерфейс {typeInterface.Name}");
        }

        public TInterface Resolve<TInterface>()
        {
            Type typeInterface = typeof(TInterface);
            if (!container.ContainsKey(typeInterface))
            {
                throw new Exception("Данный тип интерфейса не существует");
            }
            if (container.TryGetValue(typeInterface, out Type typeClass))
            {
                return (TInterface)Activator.CreateInstance(typeClass);
            }
            throw new Exception($"Зависимостей для интерфейса {typeInterface.Name} не зарегистрировано");
        }
    }
}