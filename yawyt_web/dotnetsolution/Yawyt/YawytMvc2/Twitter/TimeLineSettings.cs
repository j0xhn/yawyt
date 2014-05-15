
namespace YawytMvc2.Twitter {
	public class TimeLineRequestSettings {
		public string ScreenName { get; set; }
		public bool IncludeRts { get; set; }
		public bool ExcludeReplies { get; set; }
		public int Count { get; set; }
		public bool TrimUser { get; set; }
		public string RequestUrlFormat { get; set; }
		
		public string BuildRequestUrl() {
			return string.Format(RequestUrlFormat, ScreenName, IncludeRts.ToString().ToLower(), ExcludeReplies.ToString().ToLower(), Count, TrimUser.ToString().ToLower());
		}
	}
}