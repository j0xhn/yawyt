using YawytMvc2.Twitter.JsonTypes;
using System;
using YawytMvc2.Extensions;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;

namespace YawytMvc2.Twitter {
	public class OAuthTwitterHelper {
		private AuthenticateSettings _authSettings;

		public OAuthTwitterHelper(AuthenticateSettings authSettings) {
			_authSettings = authSettings;
		}

		private AuthResponse Authenticate() {
			Authenticator authenticator = new Authenticator();
			AuthResponse authResponse = authenticator.Authenticate(_authSettings);
			return authResponse;
		}

		public string GetTimelineJson(TimeLineRequestSettings requestSettings) {
			var timeLineJson = string.Empty;
			var authResponse = Authenticate();
			var url = requestSettings.BuildRequestUrl();
			
			timeLineJson = JsonUtil.RequestJson(url, authResponse.TokenType, authResponse.AccessToken);

			return timeLineJson;
		}

		public string GetFriendsIdsJson(FriendsIdsRequestSettings requestSettings) {
			var json = string.Empty;
			var authResponse = Authenticate();
			var url = requestSettings.BuildRequestUrl();
			
			json = JsonUtil.RequestJson(url, authResponse.TokenType, authResponse.AccessToken);

			return json;
		}

		public string GetFriendsListJson(FriendsListRequestSettings requestSettings) {
			var json = string.Empty;
			var authResponse = Authenticate();
			var url = requestSettings.BuildRequestUrl();

			json = JsonUtil.RequestJson(url, authResponse.TokenType, authResponse.AccessToken);

			return json;
		}

		////todo: see https://dev.twitter.com/docs/api/1/post/oauth/request_token
		//public string RequestToken(string callBackUrl, string oAuthConsumerKey) {
		//    string oAuthVersion = "1.0";
		//    string oAuthNonce = GenerateNonce(42);

		//    string oAuthSignature = ""; //todo: see https://dev.twitter.com/docs/auth/creating-signature and https://dev.twitter.com/discussions/15206
			
		//    string oAuthSignatureMethod = "HMAC-SHA1";
		//    string oAuthTimestamp = DateTime.Now.GetSecondsSinceUnixEpoch().ToString();


		//    //string oAuthSignatureQuery = string.Format(
		//    //    "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&q={6}",
		//    //    oAuthConsumerKey,
		//    //    oAuthNonce,
		//    //    oAuthSignatureMethod,
		//    //    oAuthTimestamp,
		//    //    "???",
		//    //    oAuthVersion
		//    //);
		//    string oAuthSignatureQuery = string.Format(
		//        "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}&oauth_timestamp={3}&oauth_version={4}",
		//        oAuthConsumerKey,
		//        oAuthNonce,
		//        oAuthSignatureMethod,
		//        oAuthTimestamp,
		//        oAuthVersion
		//    );



		//    return null;
		//}

		//todo: see https://dev.twitter.com/discussions/16281
		public string GetOAuthRequestToken(string callBackUrl, string oAuthRequestTokenUrl, string oAuthConsumerKey, string oAuthConsumerSecret) {
			var escapedConsumerKey = Uri.EscapeDataString(oAuthConsumerKey);
			var escapedConsumerSecret = Uri.EscapeDataString(oAuthConsumerSecret);
			var keySecretPair = escapedConsumerKey + ":" + escapedConsumerSecret;
			var formattedKeySecretPair = Convert.ToBase64String(Encoding.UTF8.GetBytes(keySecretPair));

			var authHeader = string.Format(
				"Basic {0}",
				formattedKeySecretPair
			);

			var postBody = "grant_type=client_credentials";

			ServicePointManager.Expect100Continue = false;

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(oAuthRequestTokenUrl);
			request.Headers.Add("Authorization", authHeader);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

			using (Stream stream = request.GetRequestStream()) {
				byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
				stream.Write(content, 0, content.Length);
			}

			request.Headers.Add("Accept-Encoding", "gzip");

			WebResponse response = request.GetResponse();

			return null;
		}

		private string GenerateNonce(int length) {
			var random = new RNGCryptoServiceProvider();
			var data = new byte[length];
			
			random.GetNonZeroBytes(data);
			var result = Convert.ToBase64String(data);

			return result;
		}
	}
}