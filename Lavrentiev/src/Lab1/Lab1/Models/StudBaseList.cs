using System;
using System.Collections.Generic;

namespace Lab1.Models
{
    public interface StudBaseList
    {
        List<Student> StudentList();
        Student ShowStudent(int id);
        void AddStudent(Student st);
        void EditStudent(Student st);
        void DeleteStudent(int id);      
    }
}