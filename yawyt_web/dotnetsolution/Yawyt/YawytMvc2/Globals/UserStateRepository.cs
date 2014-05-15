using System.Configuration;
using System.Web;
using YawytMvc2.Models;
using YawytMvc2.Twitter;

namespace YawytMvc2.Globals {
	public sealed class UserStateRepository {
		private UserStateRepository() { }

		private static OAuthTwitterHelper _twitterHelper;

		public static UserModel User {
			get {
				var user = HttpContext.Current.Session["currUser"] as UserModel;
				return user;
			}

			set {
				HttpContext.Current.Session["currUser"] = value;
			}
		}

		public static bool IsUserSignedIn { get { return User != null; } }

		public static void SignUserOut() {
			User = null;
		}

		public static OAuthTwitterHelper GetTwitterHelper() {
			if (_twitterHelper == null) {
				string consumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
				string consumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
				string oAuth2TokenUrl = ConfigurationManager.AppSettings["twitterOAuth2TokenUrl"];

				var authSettings = new AuthenticateSettings {
					OAuthConsumerKey = consumerKey,
					OAuthConsumerSecret = consumerSecret,
					OAuthUrl = oAuth2TokenUrl
				};

				_twitterHelper = new OAuthTwitterHelper(authSettings);
			}

			return _twitterHelper;
		}
	}
}