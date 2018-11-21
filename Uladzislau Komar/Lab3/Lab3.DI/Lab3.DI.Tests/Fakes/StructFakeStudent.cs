using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.DI.Tests.Fakes
{
    public struct StructFakeStudent : IFakeStudent
    {
        public string FirstName { get; set; }

        public string Do()
        {
            return "Test";
        }
    }
}
