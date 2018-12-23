using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Validation.Controllers
{
    public class OrderController : Controller
    {
        
        public ActionResult Edit(int id)
        {
            //HttpContext.User = 
            //CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            //CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");
            var random = new Random();
            var order = new Order
            {
                Id = id,
                Title = $"Spider Man {random.Next(1,4)}. DVD",
                Amount = random.Next(10, 100),
                Discont = random.Next(1, 20)
            };

            return View(order);
        }

        public JsonResult ValidateTitle(string title)
        {
            bool isValid = !title.Contains("DVD");
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            //if (order.Title.Contains("DVD"))
            //{
            //    ModelState.AddModelError("Title", "DVD is deprecated.");
            //}

            if (ModelState.IsValid)
            {
                ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Model is not valid.";
            }
            return View();
        }
        
    }
}
