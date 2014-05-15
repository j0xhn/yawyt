using System;

namespace YawytMvc2.Models
{
	public class UserModel
	{
		public string Id { get; set; }
		public string TwitterUserName { get; set; }
		public string TwitterPassword { get; set; }
		public int Score { get; set; }
		public DateTime? DateLastScored { get; set; }
	}
}