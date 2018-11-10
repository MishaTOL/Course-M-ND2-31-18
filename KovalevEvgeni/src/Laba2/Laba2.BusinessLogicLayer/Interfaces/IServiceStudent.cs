using Laba2.BusinessLogicLayer.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.BusinessLogicLayer.Interfaces
{
   public interface IServiceStudent
    {
        StudentDTO GetStudent(string LastName, string FirstName);
        IEnumerable<StudentDTO> GetStudentes();
        StudentDTO GetStudent(int studentId);
    }
}
