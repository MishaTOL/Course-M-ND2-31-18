using Lab3.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab3.Services
{
    class Student2 : IStudent
    {
        private List<string> stringList;

        public Student2(string message)
        {
            stringList = new List<string>() { message };
        }

        public Student2(List<string> list )
        {
            stringList = list;
        }

        public Student2(List<string> list, int i)
        {
            stringList = list;
            stringList.Add(i.ToString());
        }

        public void Write()
        {
            foreach(var elem in stringList)
            {
                Console.WriteLine(elem + "\n");
            }
        }
    }
}
