using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace TakYab.Areas.Admin.Controllers
{

    [Authorize(Roles = "administrator")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/



        public ActionResult Index()
        {
            return View();
        }

    }
}
