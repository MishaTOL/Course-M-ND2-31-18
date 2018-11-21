using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Lab1.Models;
using System.IO;
using System.Web.Script.Serialization;

namespace Lab1.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string path = Server.MapPath("~/App_data/data.json");
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                string json = System.IO.File.ReadAllText(path);
                if (json != "" && json != "[]" && json != null)
                {
                    List<Students> students_list = JsonConvert.DeserializeObject<List<Students>>(json);
                    ViewBag.students = students_list;
                }
                else
                {
                    List<Students> st = new List<Students>();
                    st.Add(new Students { ID = 0, Firstname = "testdata", Lastname = "testdata" });
                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(st));
                    json = JsonConvert.SerializeObject(st);
                    ViewBag.students = st;
                }
            }
            else
            {
                List<Students> st = new List<Students>();
                st.Add(new Students { ID = 0, Firstname = "testdata", Lastname = "testdata" });
                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(st));
                string json = JsonConvert.SerializeObject(st);
                ViewBag.students = st;
            }
            return View();
        }
        [HttpPost]
        public ActionResult MyAction(string submitButton, Students students)
        {
            string path = Server.MapPath("~/App_data/data.json");
            FileInfo fileInfo = new FileInfo(path);
            string json = System.IO.File.ReadAllText(path);
            List<Students> students_list = JsonConvert.DeserializeObject<List<Students>>(json);
            if (Request.Form["submitButtonCreate"] != null)
            {
                try
                {

                    var item = students_list.All(r => r.ID != students.ID);
                    if (item == true)
                    {
                        students_list.Add(new Students { ID = students.ID, Firstname = students.Firstname, Lastname = students.Lastname });
                    }

                }
                catch (Exception) { };
            }
            else if (Request.Form["submitButtonDelete"] != null)
            {

                try
                {
                    var delitem = students_list.Single(r => r.ID == students.ID);
                    students_list.Remove(delitem);
                }
                catch (Exception) { };
            }
            else if (Request.Form["submitButtonUpdate"] != null)
            {
                try
                {
                    var updateitem = students_list.FirstOrDefault(r => r.ID == students.ID);
                    if (updateitem != null)
                        updateitem.ID = students.ID;
                    updateitem.Firstname = students.Firstname;
                    updateitem.Lastname = students.Lastname;
                }
                catch (Exception) { };
            }
            using (StreamWriter file = System.IO.File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, students_list);

            }
            return RedirectToAction("Index");


        }
    }
}