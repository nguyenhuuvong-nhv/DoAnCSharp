using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Logins
        public ActionResult Index()
        {
            if (Session[Constants.USER_SESSION] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.login(user.UserName.Trim(), Encryptor.EncryptMD5(user.Password).Trim());
                if (result == 1)
                {
                    //ModelState.AddModelError("","Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, user.UserName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}