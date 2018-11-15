using System;

namespace TrialDi
{
    public class UserService : IUserService
    {
        private IUser user;

        public UserService(IUser user)
        {
            this.user = user; ;
        }

        public void Greeting()
        {
            Console.WriteLine("Hello from service!");
            user.Greeting();
            Console.ReadLine();
        }

        public void Parting()
        {
            Console.WriteLine("Goodbye from service!");
            user.Parting();
            Console.ReadLine();
        }
    }
}
