using System;

namespace TrialDi
{
    public class User : IUser
    {
        public void Greeting()
        {
            Console.WriteLine("Hello from user!");
            Console.ReadLine();
        }

        public void Parting()
        {
            Console.WriteLine("Goodbye from user!");
            Console.ReadLine();
        }
    }
}
