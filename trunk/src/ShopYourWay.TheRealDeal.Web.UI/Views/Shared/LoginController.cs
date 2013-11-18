using System.Web.Mvc;

namespace ShopYourWay.TheRealDeal.Web.UI.Controllers
{
    public class LoginController : Controller
    {
		[RequireHttps]
        public ActionResult Index()
        {
            return View();
        }

    }
}
