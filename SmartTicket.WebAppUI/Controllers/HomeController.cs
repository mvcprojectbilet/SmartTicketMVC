using SmartTicket.Business;
using SmartTicket.Business.Result;
using SmartTicket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartTicket.WebAppUI.Controllers
{
    public class HomeController : Controller
    {
        private CategoryManager cm = new CategoryManager();
        private ActivityManager am = new ActivityManager();
        // GET: Home
        public ActionResult Index()
        {
            var x = cm.List();
            return View(x);
        }

        [HttpPost]
        public ActionResult About(User user)
        {
            //Base entity data annotationları sistemsel olarak geliceği için modelstateden çıkarmamız lazm
            ModelState.Remove("CreateDate");
            ModelState.Remove("CreatedBy");
            ModelState.Remove("UpdateDate");
            ModelState.Remove("UpdatedBy");

            if (ModelState.IsValid)//Data annotation için validasyonlar 
            {
                //Required ve stringlength gibi annotationlar doğrulandıysa if e girer

                BusinessLayerResult<Activity> res = am.getuserid(10);
                if (res.Errors.Count>0)
                {
                    res.Errors.ForEach(x=>ModelState.AddModelError("",x.Message));
                    return View(user);

                }
                return RedirectToAction("ok");


            }
            return View(user);//validasyonu sağlamıyorsa modeli sayfaya aynen geri gönder
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //id gelmedi parametrede
            //return HttpNotFound(); //obje null geldi find işlemi yaptım

        }
    }
}