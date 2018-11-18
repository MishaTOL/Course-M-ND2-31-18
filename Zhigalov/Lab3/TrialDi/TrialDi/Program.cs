using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDi
{
    class Program
    {
        static void Main(string[] args)
        {
            TrialDiContainer container = new TrialDiContainer();

            container.Register<IUser, User>();
            IUser user = container.Resolve<IUser>();
            user.Greeting();
            user.Parting();

            container.Register<IUserService, UserService>();
            IUserService service = container.Resolve<IUserService>();
            service.Greeting();
            service.Parting();
        }
    }
}
