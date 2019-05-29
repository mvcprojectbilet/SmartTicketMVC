using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SmartTicket.DataAccess.EntityFramework;
using SmartTicket.Entities;

namespace SmartTicket.WebAppUI.Controllers
{
    public class AccountController : Controller
    {
        BaseRepository baserepo = new BaseRepository();

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            try
            {
                var obj = BaseRepository.context.Users.Where(a => a.Username == model.Username && a.Password == model.Password).FirstOrDefault();
                if (obj.Username != model.Username)
                {
                    ModelState.AddModelError("", "Kullanıcı adı yanlış.");
                    return View(model);
                }
                else if (obj.Password != model.Password)
                {
                    ModelState.AddModelError("", "Şifre yanlış.");
                    return View(model);
                }
                else if (obj == null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı ve şifre giriniz.");
                    return View(model);
                }

                else
                {
                    if (obj.Role == Role.Admin)
                    {
                        return RedirectToAction("About", "Home");
                    }
                    else if (obj.Role == Role.Editor)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (obj.Role == Role.User)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception)
            {

            }

            return View(model);

        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            Repository<User> repo = new Repository<User>();
            if (ModelState.IsValid)
            {
                var user = new User { Username = model.Username, Password = model.Password, ConfirmPassword = model.ConfirmPassword, Name = model.Name, Surname = model.Surname, Phone = model.Phone, Mail = model.Mail, Gender = model.Gender, BirthDay = model.BirthDay, Role = Role.User, State = State.PendingApproval, ActivedGuid = Guid.NewGuid(), CreateDate = DateTime.Now, CreatedBy = "-1", UpdateDate = DateTime.Now, UpdatedBy = "-1" };

                if (BaseRepository.context.Users.Where(x => x.Username == user.Username).FirstOrDefault() != null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı mevcut.");
                    return View();
                }
                if (BaseRepository.context.Users.Where(x => x.Mail == user.Mail).FirstOrDefault() != null)
                {
                    ModelState.AddModelError("", "E-Posta mevcut.");
                    return View();

                }
                else
                {
                    repo.Insert(user);
                    return RedirectToAction("Index", "Home");
                }


            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        public ActionResult ForgetPassword(User model)
        {

            return View(model);
        }

    }
}