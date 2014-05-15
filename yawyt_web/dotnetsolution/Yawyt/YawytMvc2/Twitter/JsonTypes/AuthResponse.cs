using Newtonsoft.Json;

namespace YawytMvc2.Twitter.JsonTypes {
	public class AuthResponse {
		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
	}
}