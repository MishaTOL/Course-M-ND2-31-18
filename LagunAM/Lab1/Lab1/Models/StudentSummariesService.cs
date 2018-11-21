using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Lab1.Views.Student;


namespace Lab1.Models
{
    public class StudentSummariesService : StudentSummaries
    {
        private string FullName;
        public StudentSummariesService()
        {
            Summaries = new List<StudentSummary>();
            FullName = StudentConsts.TestFullPath;
        }
        public StudentSummariesService(string CurrentDirectory, string DBFileName)
        {
            FullName = string.Concat(CurrentDirectory, DBFileName);
            if (File.Exists(FullName))
            {
                lock (new object())
                {
                    using (StreamReader Reader = new StreamReader(FullName))
                    {
                        string JsonValues = Reader.ReadLine();
                        if (JsonValues != null)
                        {
                            Summaries = JsonConvert.DeserializeObject<List<StudentSummary>>(JsonValues);
                        }
                        else
                        {
                            Summaries = new List<StudentSummary>();
                        }
                        Reader.Close();
                    }
                }
            }
            else
                Summaries = new List<StudentSummary>();
        }
        private void WriteSummariesToFile()
        {
            lock (new object())
            {
                // For UnitTest 
                if (FullName.Equals(StudentConsts.TestFullPath))
                    return;
                //
                using (StreamWriter Writer = new StreamWriter(FullName, false))
                {
                    string JsonValues = JsonConvert.SerializeObject(Summaries);
                    Writer.Write(JsonValues);
                    Writer.Close();
                }
            }
        }

        private StudentSummary GetStudentSummaryByID(int ID)
        {
            if (Summaries.FirstOrDefault(x => x.ID == ID) != null)
            {
                return Get(ID);
            }
            else
            {
                return null;
            }
        }

        public StudentSummary StudentInfo(int ID)
        {
            StudentSummary CurrentSummary = GetStudentSummaryByID(ID);
            return CurrentSummary;
        }

        public string NewStudent(StudentSummary studentSummary)
        {
            if (Summaries.Count > 0)
            {
                studentSummary.ID = Summaries.Max(x => x.ID) + StudentConsts.IDStep;
            }
            else
            {
                studentSummary.ID = StudentConsts.IDStep;
            }
            Add(studentSummary);
            WriteSummariesToFile();
            return StudentConsts.ResultOK;
        }

        public string ChangeStudentInfo(StudentSummary NewSummary)
        {
            StudentSummary CurrentSummary = GetStudentSummaryByID(NewSummary.ID);
            if (CurrentSummary != null)
            {
                Update(NewSummary);
                WriteSummariesToFile();
                return StudentConsts.ResultOK;
            }
            else
            {
                return StudentConsts.NotFound;
            }
            
        }

        public string StudentOut(StudentSummary DeleteSummary)
        {
            StudentSummary CurrentSummary = GetStudentSummaryByID(DeleteSummary.ID);
            if (CurrentSummary != null)
            {
                Delete(CurrentSummary);
                WriteSummariesToFile();
                return StudentConsts.ResultOK;
            }
            else
            {
                return StudentConsts.NotFound;
            }
                
        }

        public string SaveStudentSummariesInCSV()
        {
            string StringCSV = "";
            foreach (KeyValuePair<string, string> KeyValue in ActionsConst.StudentPsevdonims)
            {
                StringCSV = string.Concat(StringCSV, KeyValue.Key, ";");
            }
            StringCSV = StringCSV.Remove(StringCSV.LastIndexOf(';'));
            StringCSV = string.Concat(StringCSV, Environment.NewLine);

            foreach (StudentSummary Now in Summaries)
            {
                foreach (KeyValuePair<string, string> KeyValue in ActionsConst.StudentPsevdonims)
                {
                    StringCSV = string.Concat(StringCSV, Now.GetType().GetProperty(
                        KeyValue.Value).GetValue(Now), ";");
                }
                StringCSV = StringCSV.Remove(StringCSV.LastIndexOf(';'));
                StringCSV = string.Concat(StringCSV, Environment.NewLine);
            }
            return StringCSV;
        }
        
    }
}