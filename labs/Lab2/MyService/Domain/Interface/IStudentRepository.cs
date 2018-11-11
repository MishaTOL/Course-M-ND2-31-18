
using Lab2.MyService.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MyService.Domain.Interface
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudentList();
        IEnumerable<Post> GetPostList();
        Student Get(int id);
        void Create(Student item);
        void Update(Student item);
        void Delete(int id);
        void Save();
    }
}
