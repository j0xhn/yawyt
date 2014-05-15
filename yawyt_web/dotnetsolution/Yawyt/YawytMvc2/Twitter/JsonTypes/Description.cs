using System.Collections.Generic;
using Newtonsoft.Json;

namespace YawytMvc2.Twitter.JsonTypes {
	public class Description {
		[JsonProperty("urls")]
		public List<Url> Urls { get; set; }
	}
}