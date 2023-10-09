using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace curdviewmodel.Controllers
{
    public class HomeController : Controller
    {
        //public jayaEntities db = new jayaEntities();
        public ActionResult Index()
        {
            //GetStudent();
            return View();
        }
        

      
    }
}