using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeryNiceSchool.Controllers.Base;

namespace VeryNiceSchool.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string username, string password)
        {
            var result = _schoolFactory.GetUserService().LoginUser(username, password);

            if ((bool)result["success"])
            {
                Session["UserType"] = (UserType)result["UserType"];
            }

            return Json(result);
        }
    }
}