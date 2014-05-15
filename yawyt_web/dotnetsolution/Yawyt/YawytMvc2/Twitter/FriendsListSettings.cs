
namespace YawytMvc2.Twitter {
	public class FriendsListRequestSettings {
		public string ScreenName { get; set; }
		public int Count { get; set; }
		public bool SkipStatus { get; set; }
		public bool IncludeUserEntities { get; set; }
		public string RequestUrlFormat { get; set; }

		public string BuildRequestUrl() {
			return string.Format(RequestUrlFormat, ScreenName, Count, SkipStatus.ToString().ToLower(), IncludeUserEntities.ToString().ToLower());
		}
	}
}