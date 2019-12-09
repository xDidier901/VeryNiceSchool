using Core.Entity;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeryNiceSchool.Controllers.Base;

namespace VeryNiceSchool.Controllers
{
    public class CoursesController : BaseController
    {
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllCourses()
        {
            var result = _schoolFactory.GetCourseService().GetAllCourses();

            var isAdmin = (UserType)Session["UserType"] == UserType.Admin;

            result.Add("isAdmin", isAdmin);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetFullCourseInfo(int courseID)
        {
            return Json(_schoolFactory.GetCourseService().GetFullCourseInfo(courseID), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            return Json(_schoolFactory.GetCourseService().SaveCourse(course), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCourseByID(int courseID)
        {
            return Json(_schoolFactory.GetCourseService().DeleteCourseByID(courseID), JsonRequestBehavior.AllowGet);
        }
    }
}