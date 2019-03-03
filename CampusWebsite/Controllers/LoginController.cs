using CampusWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CampusWebsite.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_Post(LoginData credential)
        {
            CampusDataEntities campusDataEntities = new CampusDataEntities();
            if (campusDataEntities.LoginDatas.Any(member => member.userName == credential.userName && member.password == credential.password))
            {
                FormsAuthentication.SetAuthCookie(credential.userName, false);
                return Json(Url.Action("Index", "Student"));
            }
            else
            {
                return Json(Url.Action("Error", "Error"));
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}