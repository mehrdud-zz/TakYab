using System.Web.Mvc;

namespace TakYab.Areas.Advertising
{
    public class AdvertisingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Advertising";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Advertising_default",
                "Advertising/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
