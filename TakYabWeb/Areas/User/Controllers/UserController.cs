using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace TakYab.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private TakYabEntities db = new TakYabEntities();


        public ActionResult GetModelListforFooter()
        {
            var models = db.Models.Where(m => m.SubNav == true).OrderBy(m => m.SortOrder);
            return View(models.ToList());
        }
    }
}