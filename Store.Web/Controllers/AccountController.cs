using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider mAuthProvider;
        public AccountController(IAuthProvider authProvider)
        {
            mAuthProvider = authProvider;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (mAuthProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl??Url.Action("Index","Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码错误！");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}