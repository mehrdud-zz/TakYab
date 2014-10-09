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


        
        public UserProfile GetUser(string username)
        {
            var user = db.UserProfiles.First(m => m.UserName == username);
            return user;
        }


        public static string GetUsername()
        {
            if (System.Web.Security.Membership.GetUser() != null)
                return System.Web.Security.Membership.GetUser().UserName;

            return String.Empty;
        }

        public ActionResult Homepage()
        {
            return View();
        }
    }
}