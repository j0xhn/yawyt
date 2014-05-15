
namespace YawytMvc2.Twitter {
	public class FriendsIdsRequestSettings {
		public string ScreenName { get; set; }
		public int Count { get; set; }
		public string RequestUrlFormat { get; set; }
		
		public string BuildRequestUrl() { 
			return string.Format(RequestUrlFormat, ScreenName, Count);
		}
	}
}