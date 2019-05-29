using SmartTicket.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartTicket.WebAppUI.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        //private CategoryManager cm = new CategoryManager();
        //ilgili manager newlenip veri tabnaı işlemleri buradan yapılacak


        // GET: User/Home
        public ActionResult Index()
        {
            //var n = cm.Insert();
            //var n = cm.Delete();
            //var b = cm.Find();
            return View();
        }
    }
}