using System.Web.Mvc;

namespace TakYab.Areas.Ads
{
    public class AdsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Ads";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Ads_default",
                "Ads/{controller}/{action}/{id}",
                //new { controller = "Car", action = "Index", id = UrlParameter.Optional }

                new { controller = "Car", action = "Index", id = 1 }
            );
        }
    }
}
