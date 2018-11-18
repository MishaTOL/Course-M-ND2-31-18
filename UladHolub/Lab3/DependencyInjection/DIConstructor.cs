using System.Reflection;

namespace DependencyInjection
{
    public class DIConstructor
    {
        public ConstructorInfo Constructor { get; set; }
        public dynamic[] Parameters { get; set; }
    }
}
