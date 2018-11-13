namespace Lab3.DI.Tests.Fakes
{
    class FakeStudent : IFakeStudent
    {
        public string FirstName { get; set; }

        public FakeStudent()
        {

        }

        public FakeStudent(string firstName)
        {
            this.FirstName = firstName;
        }


        public string Do()
        {
            return "Hello";
        }
    }
}
