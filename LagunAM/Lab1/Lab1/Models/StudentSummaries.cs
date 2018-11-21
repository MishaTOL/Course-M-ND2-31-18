using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace Lab1.Models
{
    public class StudentSummaries : IRepository<int, StudentSummary>
    {
       
        public List<StudentSummary> Summaries;

        public StudentSummary Get(int ID)
        {
            return Summaries.First(x => (x.ID == ID));
        }

        public void Add(StudentSummary studentSummary)
        {
            Summaries.Add(studentSummary);
        }

        public void Update(StudentSummary studentSummary)
        {
            Summaries[Summaries.IndexOf(Summaries.FirstOrDefault(x => x.ID == studentSummary.ID))] = studentSummary;
        }

        public void Delete(StudentSummary studentSummary)
        {
            Summaries.Remove(studentSummary);
        }

        
            

    }
}