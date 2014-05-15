using System.Web.Mvc;
using YawytMvc2.Data;
using YawytMvc2.Globals;
using YawytMvc2.Models;
using System.Configuration;

namespace YawytMvc2.Controllers {
	public class SignInController : Controller {
		public ActionResult Index() {
			if (UserStateRepository.IsUserSignedIn) {
				return RedirectToAction("Index", "Question");
			}

			return View();
		}

		[HttpPost]
		public ActionResult SignIn(SignInModel signInModel, string returnUrl) {
			if (ModelState.IsValid) {



				//todo: Check credentials against API and get request token
				var callBackUrl = ApplicationStateRepository.GetAppRootRelativePath() + "SignIn";
				var oAuthRequestTokenUrl = ConfigurationManager.AppSettings["twitterRequestTokenUrl"];
				var oAuthConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
				var oAuthConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];

				var twitterHelper = UserStateRepository.GetTwitterHelper();
				var oAuthRequestToken = twitterHelper.GetOAuthRequestToken(callBackUrl, oAuthRequestTokenUrl, oAuthConsumerKey, oAuthConsumerSecret);









				//Retrieve the corresponding user record from YAWYT's database
				var dataAccessLayer = DataAccessLayerFactory.GetDataAccessLayer();
				var user = dataAccessLayer.GetUserByUserName(signInModel.UserName);
				if (user == null) {
					//todo: If no user record exists yet, create one and save it?

					//Handle the case in which there is no matching user
					ModelState.AddModelError("CustomError", "Incorrect user name and/or password.");
				}
				else {
					//Mark as logged in
					UserStateRepository.User = user;

					//Redirect to landing page
					return RedirectToAction("Index", "Question");
				}
			}

			// If we got this far, something failed, redisplay form
			return View("Index", signInModel);
		}
	}
}
