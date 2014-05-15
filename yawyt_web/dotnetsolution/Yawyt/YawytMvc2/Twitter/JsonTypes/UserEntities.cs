using Newtonsoft.Json;

namespace YawytMvc2.Twitter.JsonTypes {
	public class UserEntities {
		[JsonProperty("description")]
		public Description Description { get; set; }
	}
}