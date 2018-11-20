namespace Lab2.DataAccess.Abstraction
{
    public interface IContextFactory
    {
        IContext GetContext();
    }
}
