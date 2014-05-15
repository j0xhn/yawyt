using System.Web.Mvc;

namespace YawytMvc2.Controllers {
	[HandleError]
	public class HomeController : Controller {
		public ActionResult Index() {
			return RedirectToAction("Index", "SignIn");
		}
	}
}
