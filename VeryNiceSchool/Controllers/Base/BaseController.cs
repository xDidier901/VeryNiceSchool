using Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VeryNiceSchool.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected SchoolFactory _schoolFactory;

        public BaseController()
        {
            _schoolFactory = new SchoolFactory();
        }
    }
}