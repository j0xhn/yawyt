using System.Collections.Generic;
using Newtonsoft.Json;

namespace YawytMvc2.Twitter.JsonTypes {
	public class FriendsIds {
		[JsonProperty("ids")]
		public List<long> Ids { get; set; }

		[JsonProperty("next_cursor")]
		public int NextCursor { get; set; }

		[JsonProperty("next_cursor_str")]
		public string NextCursorString { get; set; }

		[JsonProperty("previous_cursor")]
		public int PreviousCursor { get; set; }

		[JsonProperty("previous_cursor_str")]
		public string PreviousCursorString { get; set; }
	}
}