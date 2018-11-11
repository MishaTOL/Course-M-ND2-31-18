using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MyService.Domain.Core
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public IEnumerable<Post> Posts { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
    }
}
