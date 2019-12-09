using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeryNiceSchool.Controllers.Base;

namespace VeryNiceSchool.Controllers
{
    public class InstructorsController : BaseController
    {
        // GET: Instructors
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllInstructors(int gender)
        {
            return Json(_schoolFactory.GetInstructorService().GetAllInstructors(gender), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetInstructorSelect()
        {
            return Json(_schoolFactory.GetInstructorService().GetInstructorSelect(), JsonRequestBehavior.AllowGet);
        }
    }
}