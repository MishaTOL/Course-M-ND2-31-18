namespace Lab3.DI.Tests.Fakes
{
    class SuperFakeStudent : FakeStudent
    {
        public SuperFakeStudent() : base()
        {

        }

        public SuperFakeStudent(string firstName) : base(firstName)
        {
            this.FirstName = firstName;
        }

        public new string Do()
        {
            return "World";
        }
    }
}
