using Lab2.DataAccess.Abstraction;

namespace Lab2.DataAccess.Context
{
    public class ContextFactory : IContextFactory
    {
        public IContext GetContext()
        {
            return new EFContext();
        }
    }
}
