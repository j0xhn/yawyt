using System.Collections.Generic;
using Newtonsoft.Json;

namespace YawytMvc2.Twitter.JsonTypes {
	public class Hashtag {
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("indices")]
		public List<int> Indices { get; set; }
	}
}