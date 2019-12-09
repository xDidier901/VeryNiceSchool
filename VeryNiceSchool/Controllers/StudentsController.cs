using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeryNiceSchool.Controllers.Base;

namespace VeryNiceSchool.Controllers
{
    public class StudentsController : BaseController
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllStudents(int gender)
        {
            return Json(_schoolFactory.GetStudentService().GetAllStudents(gender), JsonRequestBehavior.AllowGet);
        }
    }
}