using System;
using MyDependencyInjectionContainer.Abstract;

namespace MyDependencyInjectionContainer
{
    public class RegisteredObject : IRegisteredObject
    {
        public RegisteredObject()
        { }
        public Type Left { get; set; }
        public Type Right { get; set; }
        public void With<TRight>()
        {
            this.Right = typeof(TRight);
        }
        public object CreateInstance(object[] parameters)
        {
            return Activator.CreateInstance(this.Right, parameters);
        }
    }
}