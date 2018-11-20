namespace DependencyInjection
{
    public class DIResolver
    {
        private readonly DIContainer diContainer;

        public DIResolver(DIContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public T Get<T>()
        {
            var implementation = diContainer.DDependency[typeof(T)]; //exception if not found
            var constructor = diContainer.DConstructor[implementation]; //exception if not found
            return (T)constructor.Constructor.Invoke(constructor.Parameters);
        }
    }
}
